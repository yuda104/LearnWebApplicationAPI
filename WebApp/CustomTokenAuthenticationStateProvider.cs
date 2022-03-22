using Microsoft.AspNetCore.Components.Authorization;
using MyApp.Repository;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApp
{
    public class CustomTokenAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthenticationRepository authenticationRepository;
        private readonly ITokenRepository tokenRepository;

        public CustomTokenAuthenticationStateProvider(IAuthenticationRepository authenticationRepository, ITokenRepository tokenRepository)
        {
            this.authenticationRepository = authenticationRepository;
            this.tokenRepository = tokenRepository;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userName = await authenticationRepository.GetUserInfoAsync(await tokenRepository.GetToken());
            if (!string.IsNullOrWhiteSpace(userName))
            {
                var claim = new Claim(ClaimTypes.Name, userName);
                var identity = new ClaimsIdentity(new[] { claim }, "Custom Token Auth");
                var principal = new ClaimsPrincipal(identity);

                return new AuthenticationState(principal);
            }
            else
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }
    }
}
