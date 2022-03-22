using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository.ApiClient
{
    public class WebApiExecuter : IWebApiExecuter
    {
        private readonly string BaseUrl;
        private readonly HttpClient httpClient;
        private readonly ITokenRepository tokenRepository;

        public WebApiExecuter(string baseUrl, 
            HttpClient httpClient,
            ITokenRepository tokenRepository)
        {
            BaseUrl = baseUrl;
            this.httpClient = httpClient;
            this.tokenRepository = tokenRepository;
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> InvokeGet<T>(string uri)
        {
            AddTokenHeader();
            return await httpClient.GetFromJsonAsync<T>(GetUrl(uri));
        }

        public async Task<T> InvokePost<T>(string uri, T obj)
        {
            AddTokenHeader();
            var response = await httpClient.PostAsJsonAsync(GetUrl(uri), obj);
            await HandledError(response);
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<string> InvokePostReturnString<T>(string uri, T obj)
        {
            AddTokenHeader();
            var response = await httpClient.PostAsJsonAsync(GetUrl(uri), obj);
            await HandledError(response);
            return await response.Content.ReadFromJsonAsync<string>();
        }


        public async Task InvokePut<T>(string uri, T obj)
        {
            AddTokenHeader();
            var response = await httpClient.PutAsJsonAsync(GetUrl(uri), obj);
            await HandledError(response);
        }

        public async Task InvokeDelete(string uri)
        {
            AddTokenHeader();
            var response = await httpClient.DeleteAsync(GetUrl(uri));
            await HandledError(response);
        }

        public string GetUrl(string uri)
        {
            return $"{BaseUrl}/{uri}";
        }

        private static async Task HandledError(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(error);
            }
        }

        private async Task AddTokenHeader()
        {
            if (tokenRepository != null && !string.IsNullOrWhiteSpace(await tokenRepository.GetToken()))
            {
                httpClient.DefaultRequestHeaders.Remove("TokenHeader");
                httpClient.DefaultRequestHeaders.Add("TokenHeader", await tokenRepository.GetToken());
            }
        }
    }
}
