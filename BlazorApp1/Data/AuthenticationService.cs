using EquipmentRepairServiceCenter.Domain.Models.Users;
using EquipmentRepairServiceCenter.Interfaces;

namespace BlazorApp1.Data
{
    public class AuthenticationService
    {
        private readonly IAuthenticationManager _authManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(IAuthenticationManager authManager, IHttpContextAccessor httpContextAccessor) 
        {
            _authManager = authManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Login(LoginUser loginUser)
        {
            if (!await _authManager.ValidateUser(loginUser))
            {
                return null;
            }

            string token = await _authManager.CreateToken();

            _httpContextAccessor.HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions
            {
                MaxAge = TimeSpan.FromMinutes(5)
            });

            return token;
        }
    }
}
