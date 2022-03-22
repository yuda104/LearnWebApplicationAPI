using System;

namespace WebApi.Auth
{
    public class Token
    {
        public Token(string userName)
        {
            this.UserName = userName;
            this.TokenString = Guid.NewGuid().ToString();
            this.ExpiredDate = DateTime.Now.AddMinutes(1);
        }
        public string TokenString { get; set; }

        public string UserName { get; set; }

        public DateTime ExpiredDate { get; set; }
    }
}
