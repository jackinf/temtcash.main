using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpeysCloud.Main.IntegrationTests.Utils
{
    public class ResultHelper
    {
        public async Task<TResult> GetApiResult<TResult>(string requestUri)
        {
            var httpResult = await ApiClientFixture.Current.PrivateClient.GetAsync(requestUri);
            httpResult.EnsureSuccessStatusCode();
            var serializedResult = await httpResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(serializedResult);
            return result;
        }
    }
}