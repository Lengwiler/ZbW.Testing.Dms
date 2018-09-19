using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    internal class FileService
    {
        public void Save(string repositoryDir, string filePath, DateTime? valutaDatum, string bezeichnung, string selectedTypItem, DateTime erfassungsdatum, string benutzer, bool isRemoveFileEnabled, MetadataItem metadataItem)
        {
            if (bezeichnung == null || valutaDatum == null || selectedTypItem == null)
            {
                throw new Exception();
            }

            var valutaYear = valutaDatum.Value.Year;


            if (!Directory.Exists(repositoryDir + '\\' + valutaYear))
            {
                Directory.CreateDirectory(repositoryDir + '\\' + valutaYear);
            }

            string stream;

            using (StreamReader sr = new StreamReader(filePath, Encoding.Default))
            {
                stream = sr.ReadToEnd();
            }

            var guid = Guid.NewGuid();

            File.Copy(filePath, repositoryDir + '\\' + valutaYear + '\\' + guid + "_Content." + Path.GetExtension(filePath));

            if (isRemoveFileEnabled)
            {
                File.Delete(filePath);
            }

            var xmlSerializer = new XmlSerializer(typeof(MetadataItem));
            var streamWriter = new StreamWriter(repositoryDir + '\\' + valutaYear + '\\' + guid + "_Metadata.xml");
            xmlSerializer.Serialize(streamWriter, metadataItem);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
