using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public class TokenRepository : ITokenRepository
    {
        public readonly IJSRuntime iJSRuntime;
        public TokenRepository(IJSRuntime ijSRuntime)
        {
            ijSRuntime = iJSRuntime;
        }

        public async Task SetToken(string token)
        {
            await iJSRuntime.InvokeVoidAsync("sessionStorage.setItem", "token", token);
        }

        public async Task<string> GetToken()
        {
            return await iJSRuntime.InvokeAsync<string>("sessionStorage.getItem", "token");
        }
    }
}
