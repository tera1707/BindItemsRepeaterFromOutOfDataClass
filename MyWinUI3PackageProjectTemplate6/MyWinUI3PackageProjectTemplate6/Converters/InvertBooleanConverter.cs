using Microsoft.UI.Xaml.Data;
using System;

namespace MyWinUI3PackageProjectTemplate6.Converters
{
    // Example converter: invert a boolean value
    public sealed class InvertBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var myStatus = (int)value;
            var targetStatus = (int)parameter;

            return myStatus == targetStatus;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
