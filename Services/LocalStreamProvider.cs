using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace TrainFit.Services
{
    class LocalStreamProvider : IStreamProvider
    {

        public string UrlString { get; set; }


        public async Task<Stream> CreateStreamAsync(FileAccessMode accesMode)
        {
            Uri uri = new Uri(UrlString,UriKind.Absolute);
            var file =await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);
            var stream = await file.OpenAsync(accesMode);
            return stream.AsStream();


        }
    }
}
