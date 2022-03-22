using System.Collections.Generic;

namespace WebApi.Auth
{
    public class CustomUserManager : ICustomUserManager
    {
        private Dictionary<string, string> credentials = new Dictionary<string, string>() {
            { "Frank", "password" },
            { "Liu", "password1" }
        };

        private readonly ICustomTokenManager _customTokenManager;

        public CustomUserManager(ICustomTokenManager customTokenManager)
        {
            _customTokenManager = customTokenManager;
        }

        public string Authenticate(string userName, string password)
        {
            //validate the credentials
            if (credentials[userName] != password) 
                return string.Empty;


            return _customTokenManager.CreateToken(userName);
        }

    }
}
