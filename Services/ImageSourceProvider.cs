using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace TrainFit.Services
{
    public class ImageSourceProvider : IImageSourceProvider
    {
        public ImageSource GetImageSource(string exerciseName)
        {
            return new BitmapImage(new Uri(@"Assets/Images/Music.png", UriKind.Relative));
        }

        public bool HasImageSource(string exerciseName)
        {
            return true;
        }
    }
}
