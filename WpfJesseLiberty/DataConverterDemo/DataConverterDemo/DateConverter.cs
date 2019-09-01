using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataConverterDemo
{
    class DateConverter: IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var date = (DateTime)value;
            return date.ToString("d");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var date = value as string;
            DateTime outputDate;

            if(DateTime.TryParse(date, out outputDate))
            {
                return outputDate;
            }

            throw new Exception("unable to convert back");
        }
    }
}
