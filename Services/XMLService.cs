using System;
using System.IO;
using System.Xml.Serialization;
using Windows.Storage;

namespace TrainFit.Services
{
    public class XmlService
    {
        public static void WriteObjectToXmlFile<T>(T obj, string filename)
        {
            // Get the local folder.
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

            // Create a new folder name DataFolder.
            var dataFolder = local.CreateFolderAsync("DataFolder", CreationCollisionOption.OpenIfExists);

            // Create a new file named DataFile.txt.
            var file = dataFolder.CreateFileAsync("DataFile.txt", CreationCollisionOption.ReplaceExisting);

            // Write the data from the textbox.
            using (var s = file.OpenStreamForWriteAsync())
            {
                s.Write(fileBytes, 0, fileBytes.Length);
            }


            using (StreamWriter writer = File.CreateText(filename))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj);
            }
           
        }
    }
}
