using System.IO;

namespace SolidPrinciples.DIP.Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../data/document1.xml");
            var targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../data/document1.json");

            var formatConverter = new FormatConverter(
                new FileSystemStorage(),
                new SimpleDocumentDeserializer(),
                new CamelCaseJsonDocumentSerializer(),
                new FileSystemStorage());

            formatConverter.Convert(sourceFilePath, targetFilePath);
        }
    }
}
