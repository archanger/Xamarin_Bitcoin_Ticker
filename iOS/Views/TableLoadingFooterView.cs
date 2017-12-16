using Foundation;
using System;
using UIKit;

using System.Linq;

namespace Ticker.iOS.Views
{
    public partial class TableLoadingFooterView : UIView
    {

        public static TableLoadingFooterView CreateFromNib()
        {
            return UINib.FromName(typeof(TableLoadingFooterView).Name, null)
                        .Instantiate(null, null)
                        .First() as TableLoadingFooterView;
        }

        public TableLoadingFooterView (IntPtr handle) : base (handle)
        {
        }

        public void StartAnimation()
        {
            activityIndicator.StartAnimating();   
        }

        public void StopAnimation()
        {
            activityIndicator.StopAnimating();
        }
    }
}