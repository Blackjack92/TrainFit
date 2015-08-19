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
           var deserializedObject = await new Task<T>(() => { return ReadObjectFromXmlFile<T>(inputStream); });
           
            return deserializedObject;
        }



        public async Task SaveObjectToXmlAsync<T>(T objectToSave, Stream outputStream)
        {
            await new Task(() => {
               SaveObjectToXml<T>(objectToSave,outputStream);

            });
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
