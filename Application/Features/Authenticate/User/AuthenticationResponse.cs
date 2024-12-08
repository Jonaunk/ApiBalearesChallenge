﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authenticate.User
{
    public class AuthenticationResponse
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
        public bool IsVerified { get; set; }
        public string? JWToken { get; set; }
    }
}
