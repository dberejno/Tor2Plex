using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Tor2Plex.Directory.Data;

namespace Tor2Plex
{
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = "";

            switch ((DirectoryItemType) value)
            {
                case DirectoryItemType.Drive:
                image = "Images/drive.png";
                break;

                case DirectoryItemType.Folder:
                image = "Images/folder-closed.png";
                break;

                default:
                image = "Images/file.png";
                break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
