using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Streams;

namespace TrainFit.Services
{
    public class XmlSerializerService
    {
        public async Task<T> ReadObjectFromXmlFileAsync<T>(Stream inputStream)
        {
            Task<T> task = new Task<T>(() => { return ReadObjectFromXmlFile<T>(inputStream); });
           task.RunSynchronously();
                var deserializedObject = await task ;
           
            return deserializedObject;
        }



        public async Task SaveObjectToXmlAsync<T>(T objectToSave, Stream outputStream)
        {
            Task task = new Task(() => {
                SaveObjectToXml<T>(objectToSave, outputStream);

            });
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
            T objectFromXml = default(T);
            var serializer = new XmlSerializer(typeof(T));
            objectFromXml = (T)serializer.Deserialize(inputStream);
            return objectFromXml;
        }



    }
}
