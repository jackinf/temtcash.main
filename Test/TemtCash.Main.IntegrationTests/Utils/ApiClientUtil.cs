using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace SpeysCloud.Main.IntegrationTests.Utils
{
    public static class ApiClientUtils
    {
        public static async Task<TResult> HttpGet<TResult>(
            this HttpClient client,
            string requestUri,
            Dictionary<string, string> parameters = null,
            int expectedStatusCode = 200)
        {
            if (parameters != null)
                requestUri = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(requestUri, parameters);

            var httpResult = await client.GetAsync(requestUri);
            if (expectedStatusCode == 200)
            {
                httpResult.EnsureSuccessStatusCode();
            }
            else
            {
                Assert.Equal((int)httpResult.StatusCode, expectedStatusCode);
                return default(TResult);
            }
            var serializedResult = await httpResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(serializedResult);
            return result;
        }

        public static async Task<TResult> HttpPostJson<TResult>(this HttpClient client, string requestUri, object value, bool expectSuccess = true)
        {
            var contentOne = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            var httpResult = await client.PostAsync(requestUri, contentOne);
            if (expectSuccess)
                httpResult.EnsureSuccessStatusCode();
            var serializedResult = await httpResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(serializedResult);
            return result;
        }

        public static async Task<TResult> HttpPutJson<TResult>(this HttpClient client, string requestUri, object value, bool expectSuccess = true)
        {
            var contentOne = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            var httpResult = await client.PutAsync(requestUri, contentOne);
            if (expectSuccess)
                httpResult.EnsureSuccessStatusCode();

            var serializedResult = await httpResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(serializedResult);
            return result;
        }

        public static async Task<TResult> HttpDelete<TResult>(this HttpClient client, string requestUri)
        {
            var httpResult = await client.DeleteAsync(requestUri);
            httpResult.EnsureSuccessStatusCode();
            var serializedResult = await httpResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(serializedResult);
            return result;
        }
    }
}