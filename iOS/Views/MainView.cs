using Foundation;
using System;
using UIKit;

using CoreGraphics;

using Ticker.iOS.Views.Sources;

namespace Ticker.iOS.Views
{
    public partial class MainView : UIView
    {
        public MainViewSource Source { get => _source; }

        public MainView (IntPtr handle) : base (handle)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            TableView.RegisterNibForCellReuse(CryptoCurrencyCell.Nib, CryptoCurrencyCell.Key);

            TableView.SeparatorInset = UIEdgeInsets.Zero;

            TableView.RowHeight = UITableView.AutomaticDimension;
            TableView.EstimatedRowHeight = 90f;

            _source = new MainViewSource();
            _source.TableView = TableView;
            TableView.Source = _source;

            var refresh = new UIRefreshControl();
            TableView.RefreshControl = refresh;
            refresh.ValueChanged += (sender, e) => _source.OnRefreshHandler(e);

            TableView.TableFooterView = TableLoadingFooterView.CreateFromNib();
            TableView.TableFooterView.Frame = new CGRect(CGPoint.Empty, new CGSize(0, 60));
            TableView.TableFooterView.Hidden = false;
        }



        MainViewSource _source;
    }
}