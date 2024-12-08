using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Authenticate.User;
using Domain.Entities.Users;
using Domain.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Services
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly JWTSettings _jwtSettings;
        private readonly CurrentUser _user;
        public AccountService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IOptions<JWTSettings> jwtSettings, ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _user = currentUserService.User;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            var usuario = await _userManager.FindByEmailAsync(request.Email);
            if (usuario == null)
            {
                throw new ApiException($"No hay cuenta registrada con el Email {request.Email}");
            }

            var result = await _signInManager.PasswordSignInAsync(usuario.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new ApiException($"Las credenciales del usuario no son validas");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJwtToken(usuario);
            AuthenticationResponse response = new AuthenticationResponse();
            response.Id = usuario.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = usuario.Email;
            response.UserName = usuario.UserName;
            response.Apellido = usuario.Apellido;
            response.Nombre = usuario.Nombre;


            var rolesList = await _userManager.GetRolesAsync(usuario).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.IsVerified = usuario.EmailConfirmed;

            return new Response<AuthenticationResponse>(response, $"Usuario {usuario.UserName} autenticado");
        }


        public async Task<Response<AuthenticationResponse>> GetUser()
        {

            var user = await _userManager.Users
            .AsNoTracking()
            .Where(u => u.Id == _user.Id)
            .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ApiException($"Usuario no encontrado");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJwtToken(user);
            AuthenticationResponse response = new AuthenticationResponse();
            response.Id = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;
            response.Apellido = user.Apellido;
            response.Nombre = user.Nombre;

            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;

            return new Response<AuthenticationResponse>(response);

        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request)
        {
            var usuarioConElMismoUserName = await _userManager.FindByNameAsync(request.UserName);
            if (usuarioConElMismoUserName != null)
                throw new ApiException($"El nombre de usuario {request.UserName} ya fue registrado previamente");

            var usuario = new Usuario
            {
                Email = request.Email,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                UserName = request.UserName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var usuarioConElMismoCorreo = await _userManager.FindByEmailAsync(request.Email);
            if (usuarioConElMismoCorreo != null)
            {
                throw new ApiException($"El mail {request.Email} ya fue registrado previamente");
            }




            var result = await _userManager.CreateAsync(usuario, request.Password);
            if (!result.Succeeded)
                throw new ApiException($"{result.Errors}");

            return new Response<string>(usuario.Id, message: $"Usuario {usuario.UserName} registrado correctamente.");
        }

        private async Task<JwtSecurityToken> GenerateJwtToken(Usuario usuario)
        {
            var userClaims = await _userManager.GetClaimsAsync(usuario);
            var userRoles = await _userManager.GetRolesAsync(usuario);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < userRoles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", userRoles[i]));
            }



            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim("uid", usuario.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signinCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecutiryToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signinCredentials
                );

            return jwtSecutiryToken;
        }


        public async Task<List<Usuario>> GetUsuariosOrdenadosPorEmailAsync()
        {
            var usuarios = await _userManager.Users
                .OrderBy(u => u.Email)
                .ToListAsync();

            return usuarios;
        }
    }
}
