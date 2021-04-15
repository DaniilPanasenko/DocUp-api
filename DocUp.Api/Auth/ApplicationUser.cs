using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace DocUp.Api.Auth
{
    public class ApplicationUser : IApplicationUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int Id => GetUserId();

        public string Role => GetUserRole();

        private int GetUserId()
        {
            var request = _httpContextAccessor.HttpContext
                ?.User.Claims.FirstOrDefault(x => x.Type == "id");

            return int.TryParse(request?.Value, out var id) ? id : 0;
        }

        private string GetUserRole()
        {
            var request = _httpContextAccessor.HttpContext
                ?.User.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultRoleClaimType);

            return request?.Value;
        }
    }
}
