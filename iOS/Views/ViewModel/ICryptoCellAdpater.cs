using System;
namespace Ticker.iOS.Views.ViewModel
{
    public interface ICryptoCellAdpater
    {
        String Symbol { get; }
        String Name { get; }
        String Price { get; }
        String DailyChange { get; }
    }
}
