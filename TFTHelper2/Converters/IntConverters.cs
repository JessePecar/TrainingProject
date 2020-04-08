using System;
using System.Globalization;
using Xamarin.Forms;

namespace TFTHelper2.Mobile.UI.Converters
{
    public class CostToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object temp_color;
            if (value is int)
            {
                if ((int)value == 1)
                {
                    App.Current.Resources.TryGetValue("OneCost", out temp_color);
                    return (Color)temp_color;
                }
                else if ((int)value == 2)
                {
                    App.Current.Resources.TryGetValue("TwoCost", out temp_color);
                    return (Color)temp_color;
                }
                else if ((int)value == 3)
                {
                    App.Current.Resources.TryGetValue("ThreeCost", out temp_color);
                    return (Color)temp_color;
                }
                else if ((int)value == 4)
                {
                    App.Current.Resources.TryGetValue("FourCost", out temp_color);
                    return (Color)temp_color;
                }
                else if ((int)value == 5)
                {
                    App.Current.Resources.TryGetValue("FiveCost", out temp_color);
                    return (Color)temp_color;
                }
                else if((int)value == 7)
                {
                    App.Current.Resources.TryGetValue("SevenCost", out temp_color);
                    return (Color)temp_color;
                }
            }
            App.Current.Resources.TryGetValue("SecondaryDark", out temp_color);
            return (Color)temp_color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}