using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Strategy.Abstractions
{
    public interface IFileFormatStrategy
    {
        T Deserialize<T>(string filePath);
        void Serialize<T>(T dataToSerialize, string filePath);
    }
}
