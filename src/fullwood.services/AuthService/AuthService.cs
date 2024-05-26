using fullwood.domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace fullwood.services.AuthService
{
    public class AuthService(IHttpContextAccessor contextAccessor) : IAuthService
    {
        private readonly IHttpContextAccessor _contextAccessor = contextAccessor;
        private const string UserNameKey = "username";
        private const string RoleNameKey = "rolename";
        private readonly string AuthenticationScheme = "cookie";

        public async Task SignInAsync(LoginModel loginModel)
        {
            var claims = new List<Claim>(){
                new (UserNameKey, loginModel.UserName),
                new (RoleNameKey, loginModel.RoleName)
            };

            var identity = new ClaimsIdentity(claims, AuthenticationScheme, null, RoleNameKey);
            var user = new ClaimsPrincipal(identity);

            await _contextAccessor.HttpContext.SignInAsync(AuthenticationScheme, user);
        }
    }
}
