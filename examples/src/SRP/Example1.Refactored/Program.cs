using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace SolidPrinciples.SRP.Example1.Refactored
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../data/document1.xml");
            var targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../data/document1.json");

            string simpleDocumentAsXml = GetFileContent(sourceFilePath);
            var simpleDocument = DeserializeSimpleDocumentFromXml(simpleDocumentAsXml);
            var simpleDocumentAsJson = SerializeSimpleDocumentToJson(simpleDocument);
            SaveToFile(simpleDocumentAsJson, targetFilePath);
        }

        private static string GetFileContent(string sourceFilePath)
        {
            using (var sourceStream = File.OpenRead(sourceFilePath))
            using (var sourceStreamReader = new StreamReader(sourceStream))
            {
                return sourceStreamReader.ReadToEnd();
            }
        }

        private static SimpleDocument DeserializeSimpleDocumentFromXml(string simpleDocumentAsXml)
        {
            var simpleDocumentAsxDocument = XDocument.Parse(simpleDocumentAsXml);
            return new SimpleDocument
            {
                Title = simpleDocumentAsxDocument.Root.Element(nameof(SimpleDocument.Title).ToLower()).Value,
                Text = simpleDocumentAsxDocument.Root.Element(nameof(SimpleDocument.Text).ToLower()).Value
            };
        }

        private static string SerializeSimpleDocumentToJson(SimpleDocument simpleDocument)
        {
            return JsonConvert.SerializeObject(simpleDocument);
        }

        private static void SaveToFile(string content, string targetFilePath)
        {
            using (var outputStream = File.Open(targetFilePath, FileMode.Create, FileAccess.Write))
            using (var outputStreamWriter = new StreamWriter(outputStream))
            {
                outputStreamWriter.Write(content);
            }
        }
    }
}
