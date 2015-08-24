using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace TrainFit.Services
{
    public interface IStreamProvider
    {
        Task<Stream> CreateStreamAsync(FileAccessMode accessMode);
    }
}
