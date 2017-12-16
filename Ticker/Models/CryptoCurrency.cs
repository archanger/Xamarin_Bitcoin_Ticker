using System;

using Newtonsoft.Json;

namespace Ticker.Models
{
    public class CryptoCurrency
    {
        [JsonProperty (PropertyName = "id")]
        public String ID { get; set; }

        [JsonProperty (PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty (PropertyName = "symbol")]
        public String Symbol { get; set; }

        [JsonProperty (PropertyName = "rank")]
        public String Rank { get; set; }

        [JsonProperty (PropertyName = "price_usd")]
        public String PriceUSD { get; set; }

        [JsonProperty(PropertyName = "percent_change_24h")]
        public String PercentChange24 { get; set; }
    }
}
