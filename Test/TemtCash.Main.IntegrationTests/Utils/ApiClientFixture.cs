using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpeysCloud.Main.Domain.Result;

namespace SpeysCloud.Main.IntegrationTests.Utils
{
    public sealed class ApiClientFixture
    {
        public static readonly ApiClientFixture Current = new ApiClientFixture();

        /// <summary>
        /// Client, which can access private routes thanks to that he is logged in and has valid token
        /// which is created and assigned in <see cref="ApiClientFixture"/> constructor.
        /// </summary>
        public HttpClient PrivateClient { get; }
        
        private ApiClientFixture()
        {
            PrivateClient = ApiServerFixture.Current.Server.CreateClient();
            
            // Register
            var email = $"test{Guid.NewGuid()}@test.com";
            var requestDataOne = new { Email = email, Password = "123456aA!" };
            var contentOne = new StringContent(JsonConvert.SerializeObject(requestDataOne), Encoding.UTF8, "application/json");
            var resultOne = PrivateClient.PostAsync("/Account/Register", contentOne).Result;
            resultOne.EnsureSuccessStatusCode();
            
            // Login
            var requestDataTwo = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", email),
                new KeyValuePair<string, string>("password", "123456aA!")
            };
            var contentTwo = new FormUrlEncodedContent(requestDataTwo);
            var resultTwo = PrivateClient.PostAsync("/connect/token", contentTwo).Result;
            resultTwo.EnsureSuccessStatusCode();
            string responseContentStr = resultTwo.Content.ReadAsStringAsync().Result;
            var responseContent = JsonConvert.DeserializeObject<OpenIddictSignInResult>(responseContentStr);
            
            PrivateClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(responseContent.TokenType, responseContent.AccessToken);
        }
        
        public async Task<TResult> HttpGet<TResult>(string requestUri, Dictionary<string, string> parameters = null)
        {
            if (parameters != null)
                requestUri = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(requestUri, parameters);

            var httpResult = await PrivateClient.GetAsync(requestUri);
            httpResult.EnsureSuccessStatusCode();
            var serializedResult = await httpResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(serializedResult);
            return result;
        }

        public async Task<TResult> HttpPostJson<TResult>(string requestUri, object value)
        {
            var contentOne = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            var httpResult = await PrivateClient.PostAsync(requestUri, contentOne);
            httpResult.EnsureSuccessStatusCode();
            
            var serializedResult = await httpResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(serializedResult);
            return result;
        }

        public async Task<TResult> HttpPutJson<TResult>(string requestUri, object value)
        {
            var contentOne = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            var httpResult = await PrivateClient.PutAsync(requestUri, contentOne);
            httpResult.EnsureSuccessStatusCode();
            
            var serializedResult = await httpResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(serializedResult);
            return result;
        }
        
        public async Task<TResult> HttpDelete<TResult>(string requestUri)
        {
            var httpResult = await PrivateClient.DeleteAsync(requestUri);
            httpResult.EnsureSuccessStatusCode();
            var serializedResult = await httpResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(serializedResult);
            return result;
        }

        ~ApiClientFixture()
        {
            Dispose();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            // Run at end
        }        
    }
}