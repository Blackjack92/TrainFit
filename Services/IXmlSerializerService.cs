using System.IO;
using System.Threading.Tasks;

namespace TrainFit.Services
{
    public interface IXmlSerializerService
    {
        Task<T> ReadObjectFromXmlFileAsync<T>(Stream inputStream);

        Task SaveObjectToXmlAsync<T>(T objectToSave, Stream outputStream);

        void SaveObjectToXml<T>(T objectToSave, Stream outputStream);

        T ReadObjectFromXmlFile<T>(Stream inputStream);
    }
}