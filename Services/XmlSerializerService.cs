using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TrainFit.Services
{
    public class XmlSerializerService : IXmlSerializerService
    {
        #region methods
        public async Task<T> ReadObjectFromXmlFileAsync<T>(Stream inputStream)
        {
            Task<T> task = new Task<T>(() => { return ReadObjectFromXmlFile<T>(inputStream); });
            task.RunSynchronously();
            return await task;
        }

        public async Task SaveObjectToXmlAsync<T>(T objectToSave, Stream outputStream)
        {
            Task task = new Task(() => { SaveObjectToXml<T>(objectToSave, outputStream); });
            task.RunSynchronously();
            await task;
        }

        public void SaveObjectToXml<T>(T objectToSave, Stream outputStream)
        {
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(outputStream, objectToSave);
        }

        public T ReadObjectFromXmlFile<T>(Stream inputStream)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(inputStream);
        }
        #endregion
    }
}
