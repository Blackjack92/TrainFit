using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace TrainFit.Services
{
   public interface IStreamProvider
    {

        Task<Stream> CreateStream();

    }
}
