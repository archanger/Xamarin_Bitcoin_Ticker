using System;
using UIKit;

namespace Ticker.iOS.Utils
{
    public interface ICustomViewController<TView> where TView : UIView
    {
        TView CustomView { get; set; }
    }
}
