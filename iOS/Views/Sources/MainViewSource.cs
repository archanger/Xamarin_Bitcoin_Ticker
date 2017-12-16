using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;

using UIKit;

using Ticker.iOS.Views.ViewModel;
using Ticker.Utils;
using CoreGraphics;

namespace Ticker.iOS.Views.Sources
{
    public class MainViewSource : UITableViewSource
    {
        public UITableView TableView { get; set; }

        public event EventHandler RefreshHanler;
        public event EventHandler LoadMoreHandler;

        public void OnRefreshHandler(EventArgs e)
        {
            RefreshHanler?.Invoke(this, e);
        }

        protected void OnLoadMoreHandler(EventArgs e)
        {
            if (_isLoadingMore == false) {
                _isLoadingMore = true;
                _loadingFooter.Hidden = false;
                _loadingFooter.StartAnimation();
                TableView.ContentSize = new CGSize(TableView.ContentSize.Width,
                                                   TableView.ContentSize.Height + 60);
                LoadMoreHandler?.Invoke(this, e);
            }
        }

        public void StopLoadingMore()
        {
            _isLoadingMore = false;
            _loadingFooter.Hidden = true;
            UIView.Animate(0.3f, () => {
                TableView.ContentSize = new CGSize(TableView.ContentSize.Width,
                                                   TableView.ContentSize.Height - 60);    
            });

            TableView.RefreshControl.EndRefreshing();
            _loadingFooter.StopAnimation();
        }

        public void ClearData() 
        {
            _cache.Clear();
            TableView.ReloadData();
        }

        public void AppendData(IEnumerable<ICryptoCellAdpater> data)
        {
            var firstNewIndex = _cache.Count;
            _cache.Add(data);
            var lastNewIndex = _cache.Count;

            var pathsToInsert = new List<NSIndexPath>();
            for (int i = firstNewIndex; i < lastNewIndex; i++)
            {
                pathsToInsert.Add(NSIndexPath.FromRowSection(i, 0));
            }

            TableView.BeginUpdates();
            TableView.InsertRows(pathsToInsert.ToArray(), UITableViewRowAnimation.Automatic);
            TableView.EndUpdates();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CryptoCurrencyCell.Key, indexPath) as CryptoCurrencyCell;

            var item = _cache.ElementAt(indexPath.Row);

            cell.ApplyData(item);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _cache.Count();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override void Scrolled(UIScrollView scrollView)
        {


            var currentOffset = scrollView.ContentOffset.Y;
            var maximumOffset = scrollView.ContentSize.Height - scrollView.Frame.Height;
            var deltaOffset = maximumOffset - currentOffset;

            if (deltaOffset <= 0) {
                OnLoadMoreHandler(EventArgs.Empty);
			}

        }

        TableLoadingFooterView _loadingFooter => TableView.TableFooterView as TableLoadingFooterView;

        ICollection<ICryptoCellAdpater> _cache = new List<ICryptoCellAdpater>();
        Boolean _isLoadingMore;
    }
}
