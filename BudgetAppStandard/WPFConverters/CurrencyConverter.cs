using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFConverters
{
    public class CurrencyConverter : BaseValueConverter<CurrencyConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double dollarAmount = (double)value;
            return dollarAmount.ToString("C", CultureInfo.CurrentCulture);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            //double resultValue;
            if (double.TryParse(strValue, out double resultValue))
            {
                return resultValue;
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
