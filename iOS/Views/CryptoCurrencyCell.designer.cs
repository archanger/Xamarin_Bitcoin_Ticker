// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Ticker.iOS.Views
{
    [Register ("CryptoCurrencyCell")]
    partial class CryptoCurrencyCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DayChangeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PriceLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SymbolLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DayChangeLabel != null) {
                DayChangeLabel.Dispose ();
                DayChangeLabel = null;
            }

            if (NameLabel != null) {
                NameLabel.Dispose ();
                NameLabel = null;
            }

            if (PriceLabel != null) {
                PriceLabel.Dispose ();
                PriceLabel = null;
            }

            if (SymbolLabel != null) {
                SymbolLabel.Dispose ();
                SymbolLabel = null;
            }
        }
    }
}