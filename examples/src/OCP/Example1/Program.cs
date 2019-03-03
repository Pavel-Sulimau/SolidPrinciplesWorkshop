using System.IO;

namespace SolidPrinciples.OCP.Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Data/Document1.xml");
            var targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Data/Document1.json");

            var formatConverter = new FormatConverter();
            formatConverter.Convert(sourceFilePath, targetFilePath);
        }
    }
}
