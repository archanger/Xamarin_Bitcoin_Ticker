using System;

using Foundation;
using UIKit;

using Ticker.iOS.Views.ViewModel;

namespace Ticker.iOS.Views
{
    public partial class CryptoCurrencyCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("CryptoCurrencyCell");
        public static readonly UINib Nib;

        static CryptoCurrencyCell()
        {
            Nib = UINib.FromName("CryptoCurrencyCell", NSBundle.MainBundle);
        }

        protected CryptoCurrencyCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void ApplyData(ICryptoCellAdpater adapter)
        {
            SymbolLabel.Text = adapter.Symbol;
            NameLabel.Text = adapter.Name;
            PriceLabel.Text = "$ " + adapter.Price;

            try
            {
                if (Double.Parse(adapter.DailyChange) < 0) {
                    DayChangeLabel.TextColor = UIColor.Red;
                } else {
                    DayChangeLabel.TextColor = UIColor.Green;
                }

                DayChangeLabel.Text = adapter.DailyChange + "%";
            }
            catch
            {
                DayChangeLabel.TextColor = UIColor.Black;
                DayChangeLabel.Text = "-";
            }
        }
    }
}
