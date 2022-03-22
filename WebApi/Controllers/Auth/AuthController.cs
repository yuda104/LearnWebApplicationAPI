using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Auth;

namespace WebApi.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICustomTokenManager _customTokenManager;
        private readonly ICustomUserManager _customUserManager;

        public AuthController(ICustomTokenManager customTokenManager, ICustomUserManager customUserManager)
        {
            _customTokenManager = customTokenManager;
            _customUserManager = customUserManager;
        }
         
        [HttpPost]
        [Route("/authenticate")]
        public Task<string> Authenticate(UserCredential userCredential)
        {
            return Task.FromResult(_customUserManager.Authenticate(userCredential.userName, userCredential.password));
        }

        [HttpGet]
        [Route("/verify")]
        public Task<bool> Verify(string token)
        {
            return Task.FromResult(_customTokenManager.VerifyToken(token));
        }

        [HttpGet]
        [Route("/getuserinfo")]
        public Task<string> GetUserInfoByToken(string token)
        {
            return Task.FromResult(_customTokenManager.GetUserInfoByToken(token));
        }
    }

    public class UserCredential
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
