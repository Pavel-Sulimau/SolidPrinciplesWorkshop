using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SolidPrinciples.SRP.Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../../../../data/document1.xml");
            var targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../../../../data/document1.json");

            string simpleDocumentAsXml;
            using (var sourceStream = File.OpenRead(sourceFilePath))
            using (var sourceStreamReader = new StreamReader(sourceStream))
            {
                simpleDocumentAsXml = sourceStreamReader.ReadToEnd();
            }

            var simpleDocumentAsxDocument = XDocument.Parse(simpleDocumentAsXml);
            var simpleDocument = new SimpleDocument
            {
                Title = simpleDocumentAsxDocument.Root.Element(nameof(SimpleDocument.Title).ToLower()).Value,
                Text = simpleDocumentAsxDocument.Root.Element(nameof(SimpleDocument.Text).ToLower()).Value
            };

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var simpleDocumentAsJson = JsonConvert.SerializeObject(simpleDocument, settings);

            using (var outputStream = File.Open(targetFilePath, FileMode.Create, FileAccess.Write))
            using (var outputStreamWriter = new StreamWriter(outputStream))
            {
                outputStreamWriter.Write(simpleDocumentAsJson);
            }
        }
    }

    public class SimpleDocument
    {
        public string Title { get; set; }

        public string Text { get; set; }
    }
}
