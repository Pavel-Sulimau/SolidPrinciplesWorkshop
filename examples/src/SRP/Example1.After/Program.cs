using System.IO;

namespace SolidPrinciples.SRP.Example1.After
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../../../../data/document1.xml");
            var targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../../../../data/document1.json");

            var formatConverter = new FormatConverter();
            formatConverter.Convert(sourceFilePath, targetFilePath);
        }
    }
}
