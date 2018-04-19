using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;

namespace SpeysCloud.Main.IntegrationTests.Utils
{
    public class FakePolicyEvaluator : IPolicyEvaluator
    {
        public virtual async Task<AuthenticateResult> AuthenticateAsync(AuthorizationPolicy policy, HttpContext context)
        {
            var principal = new ClaimsPrincipal();
            principal.AddIdentity(new ClaimsIdentity(
                new[] {
                    new Claim("Permission", "CanViewPage"),
                    new Claim("Manager", "yes"),
                    new Claim(ClaimTypes.Role, "Administrator"),
                    new Claim(ClaimTypes.NameIdentifier, "John")
                },
                "FakeScheme"));
            AuthenticateResult success = AuthenticateResult.Success(new AuthenticationTicket(principal,
                new AuthenticationProperties(), "FakeScheme"));
            return await Task.FromResult(success);
        }

        public virtual async Task<PolicyAuthorizationResult> AuthorizeAsync(
            AuthorizationPolicy policy, 
            AuthenticateResult authenticationResult, 
            HttpContext context, 
            object resource)
        {
            return await Task.FromResult(PolicyAuthorizationResult.Success());
        }

        public virtual async Task<PolicyAuthorizationResult> AuthorizeAsync(
            AuthorizationPolicy policy, 
            AuthenticateResult authenticationResult, 
            HttpContext context)
        {
            return await Task.FromResult(PolicyAuthorizationResult.Success());
        }
    }
}