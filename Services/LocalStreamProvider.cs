using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace TrainFit.Services
{
    public class LocalStreamProvider : IStreamProvider
    {
        #region properties
        private string urlString;
        #endregion

        #region ctor
        public LocalStreamProvider(string urlString)
        {
            this.urlString = urlString;
        }
        #endregion

        #region methods
        public async Task<Stream> CreateStreamAsync(FileAccessMode accesMode)
        {
            Uri uri = new Uri(urlString, UriKind.Absolute);
            var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
            var stream = await file.OpenAsync(accesMode);
            return stream.AsStream();
        }
        #endregion
    }
}
