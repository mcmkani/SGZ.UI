﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SGZ.AutoRefresh.UI
{
    public class TicketDetailsConverter : IValueConverter
    {
        
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo info)
        {
            if (value != null)
            {
                var data = value as double?;
                if (data > 0)
                    return
                        "F1M1719.66,218.12L1735.66,246.166 1751.66,274.21 1719.66,274.21 1687.66,274.21 1703.66,246.166 1719.66,218.12z";
                else
                    return
                        "F1M1464.78,374.21C1466.31,374.21,1466.94,375.538,1466.17,376.861L1435.89,429.439C1435.12,430.759,1433.87,430.823,1433.11,429.5L1402.82,376.827C1402.06,375.507,1402.69,374.21,1404.21,374.21L1464.78,374.21z";
            }
            return "";
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo info)
        {
            throw new NotImplementedException();
        }
    }

    public class ChangeForegroundConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo info)
        {
            var data = value as double?;
            if (data != null && data > 0)
                return new SolidColorBrush(Colors.Green);
            else
                return new SolidColorBrush(Colors.Red);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo info)
        {
            throw new NotImplementedException();
        }
    }

}
