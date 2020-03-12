using Pattern.Strategy.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Pattern.Strategy.Implementations
{
    public class XmlFormatStrategy : IFileFormatStrategy
    {
        public T Deserialize<T>(string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public void Serialize<T>(T dataToSerialize, string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (var xmlTextWriter = new XmlTextWriter(stream, Encoding.GetEncoding("ISO-8859-1")))
                {
                    var xmlSerializer = new XmlSerializer(dataToSerialize.GetType());
                    xmlSerializer.Serialize(xmlTextWriter, dataToSerialize);
                }
            }
        }
    }
}
