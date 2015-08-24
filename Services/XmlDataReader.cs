using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace TrainFit.Services
{
    public class XmlDataReader<T> : IDataReader<T>
    {
        #region fields
        private IStreamProvider streamProvider;
        private IXmlSerializerService xmlSerializer;
        #endregion

        #region ctor
        public XmlDataReader(IStreamProvider streamProvider, IXmlSerializerService xmlSerializer)
        {
            this.streamProvider = streamProvider;
            this.xmlSerializer = xmlSerializer;
        }
        #endregion

        #region methods
        public async Task<ICollection<T>> ReadAllAsync()
        {
            ICollection<T> readObjects;
            using (var stream = await streamProvider.CreateStreamAsync(FileAccessMode.Read))
            {
                readObjects= await xmlSerializer.ReadObjectFromXmlFileAsync<List<T>>(stream);
            }

            return readObjects;
        }
        #endregion
    }
}
