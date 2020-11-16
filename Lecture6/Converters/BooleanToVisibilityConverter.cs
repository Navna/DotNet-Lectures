using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Lecture6.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Если false, то ложь означает невидимость, а истина - видимость.
        /// Если true, то ложь означает видимость, а истина - невидимость.
        /// </summary>
        public bool IsInversed { get; set; }

        /// <summary>
        /// Если false, то для невидимости возвращаем <see cref="Visibility.Collapsed"/>.
        /// Если true, то для невидимости возвращаем <see cref="Visibility.Hidden"/>.
        /// </summary>
        public bool IsHidden { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool flag))
                throw new NotImplementedException();

            if (IsInversed)
                flag = !flag;

            return flag ? Visibility.Visible : (IsHidden ? Visibility.Hidden : Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
