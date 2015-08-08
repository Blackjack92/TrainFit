using System;
using System.IO;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace TrainFit.Services
{
    public class ImageSourceProvider : IImageSourceProvider
    {
        public ImageSource GetImageSource(string exerciseName)
        {
            return new BitmapImage(new Uri("ms-appx:///Assets/Images/Music.png", UriKind.Absolute));
        }

        public bool HasImageSource(string exerciseName)
        {
            return true;
        }
    }
}
