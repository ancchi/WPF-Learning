﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Block1Uebung3.Converters {
    class BooleanToColorIValueConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

            if (value == null) {
                return new SolidColorBrush(Colors.Transparent);
            }

            bool transformed;
            
            if (!bool.TryParse(value.ToString(), out transformed)) {
                throw new ArgumentException("Value is not a bool.");
            } 

            return transformed ? new SolidColorBrush(Colors.LightGreen) : new SolidColorBrush(Colors.Red);
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

    }
}
