using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace TrainFit.Services
{
    public interface IDataReader<T>
    {
        Task<ICollection<T>> ReadAll();
    }

    public class XmlDataReader<T> : IDataReader<T>
    {
        public IStreamProvider StreamProvider { get; set; }
        public XmlSerializerService XmlSerializerService { get; set; }


        public XmlDataReader(IStreamProvider streamProvider,XmlSerializerService xmlSerializer)
        {
            StreamProvider = streamProvider;
            XmlSerializerService = xmlSerializer;
        }


        public async Task<ICollection<T>> ReadAll()
        {

            ICollection<T> readObjects;
            using (var stream = await StreamProvider.CreateStreamAsync(FileAccessMode.Read))
            {
                readObjects= await XmlSerializerService.ReadObjectFromXmlFileAsync<List<T>>(stream);
            }

            return readObjects;
        }
    }
}
