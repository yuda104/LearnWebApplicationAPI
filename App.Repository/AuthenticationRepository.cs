using MyApp.Repository.ApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IWebApiExecuter _webApiExecuter;
        private readonly ITokenRepository _tokenRepository;
        public AuthenticationRepository(IWebApiExecuter webApiExecuter,
            ITokenRepository tokenRepository)
        {
            _webApiExecuter = webApiExecuter;
            _tokenRepository = tokenRepository;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var token = await _webApiExecuter.InvokePostReturnString("authenticate", new { userName = username, password = password });
            await _tokenRepository.SetToken(token);
            if (string.IsNullOrWhiteSpace(token) || token == "\"\"") return null;

            return token;
        }

        public async Task<string> GetUserInfoAsync(string token)
        {
            var userName = await _webApiExecuter.InvokePostReturnString("getuserinfo", new { token = token });
            if (string.IsNullOrWhiteSpace(userName) || userName == "\"\"") return null;

            return userName;
        }
    }
}
