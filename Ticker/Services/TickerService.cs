using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Ticker.Models;
using Ticker.Utils;

namespace Ticker.Services
{
    public class TickerService
    {

        static String EntryPoint = "https://api.coinmarketcap.com/v1/ticker/";


        public HttpClient client { get; set; } = new HttpClient();

        public async Task<IEnumerable<CryptoCurrency>> GetCurrencies(ListParams options) 
        {

            var entryPoint = EntryPoint + "?" + $"start={options.Offset}&limit={options.Limit}";

            IEnumerable<CryptoCurrency> result = null;

            HttpResponseMessage response = await client.GetAsync(entryPoint);

            if (response.IsSuccessStatusCode) {
                result = await response.Content.ReadAsAsync<IEnumerable<CryptoCurrency>>();
            }

            return result;
        }
    }
}
