using Pattern.Strategy.Implementations;
using System;
using System.IO;

namespace Pattern.Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var systemPath = AppDomain.CurrentDomain.BaseDirectory;
            var xmlFilePath = Path.Combine(systemPath, "params.xml");
            var jsonFilePath = Path.Combine(systemPath, "params.json");

            // Yes I know, "new is glue", never new up... But this is only for demo purposes. In production code we should ofcourse use an ioc container or similar to inject the concrete strategies via constructor or similar.
            var xmlStrategy = new XmlFormatStrategy();
            var jsonStrategy = new JsonFormatStrategy();

            var parameters = new ImportantParameters { Factor = 1.5, TimeoutInMs = 1000, DefaultStringValue = "xyz" };

            xmlStrategy.Serialize(parameters, xmlFilePath);
            jsonStrategy.Serialize(parameters, jsonFilePath);

            var paramsFromXml = xmlStrategy.Deserialize<ImportantParameters>(xmlFilePath);
            var paramsFromJson = jsonStrategy.Deserialize<ImportantParameters>(jsonFilePath);

            File.Delete(xmlFilePath);
            File.Delete(jsonFilePath);
        }
    }

    /// <summary>
    /// Just some made up parameters..
    /// </summary>
    public class ImportantParameters 
    {
        public double Factor { get; set; }
        public int TimeoutInMs { get; set; }
        public string DefaultStringValue { get; set; }
    }
}
