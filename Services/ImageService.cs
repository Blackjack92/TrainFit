using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Media;

namespace TrainFit.Services
{
    public class ImageService
    {
        #region properties
        internal IEnumerable<IImageSourceProvider> Providers { get; private set; }
        #endregion

        #region ctor
        public ImageService(IEnumerable<IImageSourceProvider> providers)
        {
            Providers = providers;
        }
        #endregion

        #region methods
        public ImageSource GetImageSource(string exerciseType)
        {
            return Providers.First().GetImageSource(exerciseType);
        }
        #endregion
    }
}
