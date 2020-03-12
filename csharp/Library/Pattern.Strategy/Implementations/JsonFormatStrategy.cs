using Newtonsoft.Json;
using Pattern.Strategy.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pattern.Strategy.Implementations
{
    public class JsonFormatStrategy : IFileFormatStrategy
    {
        public T Deserialize<T>(string filePath)
        {
            using (var sr = new StreamReader(filePath, Encoding.GetEncoding("ISO-8859-1")))
            {
                var serializer = new JsonSerializer();
                var data = (T)serializer.Deserialize(sr, typeof(T));
                return data;
            }
        }

        public void Serialize<T>(T dataToSerialize, string filePath)
        {
            var serializer = new JsonSerializer
            {
                DateFormatString = "yyyy-MM-dd",
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,

            };

            using (var sw = new StreamWriter(filePath, false, Encoding.GetEncoding("ISO-8859-1")))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, dataToSerialize);
            }
        }
    }
}
