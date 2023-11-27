using System;
using System.Globalization;
using System.Windows.Data;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Utilities.View
{
    /// <summary>
    /// 實做 IMultiValueConverter 介面，提供繫結多參數轉換邏輯，
    /// 繫結 ActualWidth/ActualHeight 及 Zoom 的值，轉出縮放後的值，提供長寛同時縮放以保待比例
    /// </summary>
    public class MultiBindingMultiplier :
        IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length > 1)
            {
                try
                {
                    double value = (double)values[0];
                    for (int i = 1; i < values.Length; i++)
                    {
                        value = value * (double)values[i];
                    }
                    return value;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
