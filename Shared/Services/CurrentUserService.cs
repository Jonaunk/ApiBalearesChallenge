using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor? _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            if (_httpContextAccessor is null || _httpContextAccessor.HttpContext is null)
            {
                User = new CurrentUser(Guid.Empty.ToString(), string.Empty, false);

                return;
            }

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext!.User!.Identity!.IsAuthenticated == false)
            {
                User = new CurrentUser(Guid.Empty.ToString(), string.Empty, false);

                return;
            }

            var id = httpContext.User.Claims
                .FirstOrDefault(q => q.Type == "uid")!
                .Value;

            var userName = httpContext.User!.Identity!.Name ?? "Unknown";

            User = new CurrentUser(id, userName, true);
        }

        public CurrentUser User { get; }

        public bool IsInRole(string roleName) =>
            _httpContextAccessor!.HttpContext!.User.IsInRole(roleName);
    }
}

