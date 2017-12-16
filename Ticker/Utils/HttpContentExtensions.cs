using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ticker.Utils
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            var resultString = await content.ReadAsStringAsync();

            var  result = JsonConvert.DeserializeObject<T>(resultString);

            return result;
        }
    }
}
