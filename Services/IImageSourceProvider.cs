using System;
using Windows.UI.Xaml.Media;

namespace TrainFit.Services
{
    public interface IImageSourceProvider
    {
        ImageSource GetImageSource(string exerciseName);
        bool HasImageSource(string exerciseName);
    }
}