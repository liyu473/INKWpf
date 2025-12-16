using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace OperaMaster.Converter;

/// <summary>
/// 将颜色转换为淡色，透明度通过 ConverterParameter 指定（默认 20）
/// </summary>
public class ColorToLightColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Color color)
        {
            byte alpha = 20;
            if (parameter is string s && byte.TryParse(s, out var a))
            {
                alpha = a;
            }
            return Color.FromArgb(alpha, color.R, color.G, color.B);
        }
        return Colors.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
