using System;
using System.Linq;

using UIKit;
using Foundation;

namespace Ticker.iOS.Utils
{
    public class CustomViewController<TView> : UIViewController, ICustomViewController<TView> where TView : UIView
    {
        public TView CustomView { get; set; }

        public override void LoadView()
        {
            var nib = UINib.FromName(typeof(TView).Name, null);
            View = nib.Instantiate(null, null).First() as UIView;

            CustomView = View as TView;
        }
    }
}
