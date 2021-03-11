using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using buckstore.manager.service.environment.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace buckstore.manager.service.api.v1.Filters.AuthorizationFilters
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(params string [] roles) : base(typeof(AuthorizeRolesFilter))
        {
            Arguments = new [] { roles };
        }
    }
    public class AuthorizeRolesFilter : Attribute, IAsyncResourceFilter
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger _logger;
        private readonly string[] _roles;

        public AuthorizeRolesFilter(JwtSettings jwtSettings, ILogger<AuthorizeRolesFilter> logger, string[] roles)
        {
            _jwtSettings = jwtSettings;
            _logger = logger;
            _roles = roles;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            string authHeader = context.HttpContext.Request.Headers["Authorization"];
            var token = !(string.IsNullOrEmpty(authHeader)) ? authHeader.Replace("Bearer ", "") : "";

            try
            {
                var tokenClaims = GetTokenClaims(token);
                var userRole = tokenClaims.FirstOrDefault(claim => claim.Type == "Role");
                var isRoleValid = _roles.Contains(userRole.Value);
                
                if (!isRoleValid)
                {
                    context.Result = new UnauthorizedResult();
                    await context.Result.ExecuteResultAsync(context);
                    _logger.LogWarning("Usuário passou um  token sem acesso na rota {0}.", context.HttpContext.Request.Path);
                }
                else
                {
                    await next();
                }
            }
            catch (ArgumentNullException e)
            {
                context.Result = new UnauthorizedResult();
                _logger.LogWarning("Usuário não passou um token na rota {0}", context.HttpContext.Request.Path);
            }
        }
        
        private IEnumerable<Claim> GetTokenClaims(string token)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidIssuer = _jwtSettings.TokenIssuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
            return tokenValid.Claims;
        }
    }
}