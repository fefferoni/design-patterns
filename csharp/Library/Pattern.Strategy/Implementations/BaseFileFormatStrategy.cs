using Pattern.Strategy.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pattern.Strategy.Implementations
{
    public abstract class BaseFileFormatStrategy : IFileFormatStrategy
    {
        public abstract T Deserialize<T>(string filePath);
        public abstract void Serialize<T>(T dataToSerialize, string filePath);

        public string GetFileContentsAsString(string filePath)
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
