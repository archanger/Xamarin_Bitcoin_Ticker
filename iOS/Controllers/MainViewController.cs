using System;
using UIKit;

using System.Linq;

using Ticker.iOS.Utils;
using Ticker.iOS.Views;
using Ticker.Services;
using Ticker.iOS.Views.Sources;
using Ticker.iOS.Adapters;
using System.Threading.Tasks;
using System.Threading;

namespace Ticker.iOS.Controllers
{
    public class MainViewController : CustomViewController<MainView>
    {

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Automatic;
            }

            Title = "Crypto Currency";

            _viewSource = CustomView.Source;

            _viewSource.LoadMoreHandler += (sender, e) => LoadData();

            _viewSource.RefreshHanler += (sender, e) => ReloadData();

            LoadData();
        }

        async void LoadData()
        {
            _currentParams.Offset += _currentParams.Limit;

            var currencies = await _service.GetCurrencies(_currentParams);

            _viewSource.AppendData(
                currencies.Select((currency) => new CryptoCurrencyAdapter(currency))
            );
            _viewSource.StopLoadingMore();
        }

        async void ReloadData()
        {
            _currentParams.Offset = 0;
            var currencies = await _service.GetCurrencies(_currentParams);
            _viewSource.ClearData();
            _viewSource.AppendData(
                currencies.Select((currency) => new CryptoCurrencyAdapter(currency))
            );
            _viewSource.StopLoadingMore();
        }

        Boolean HandleBooleanRequest()
        {
            LoadData();
            return true;
        }

        TickerService _service = new TickerService();
        MainViewSource _viewSource;
        ListParams _currentParams = new ListParams() { Limit = 10, Offset = -10};
    }
}
