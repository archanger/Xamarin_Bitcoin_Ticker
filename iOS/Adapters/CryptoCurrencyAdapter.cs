using System;

using Ticker.Models;
using Ticker.iOS.Views.ViewModel;

namespace Ticker.iOS.Adapters
{
    public class CryptoCurrencyAdapter : ICryptoCellAdpater
    {
        public string Symbol  => _currency.Symbol;

        public string Name => _currency.Name;

        public string Price => _currency.PriceUSD;

        public string DailyChange => _currency.PercentChange24;

        public CryptoCurrencyAdapter(CryptoCurrency currency) => _currency = currency;

        CryptoCurrency _currency;
    }
}
