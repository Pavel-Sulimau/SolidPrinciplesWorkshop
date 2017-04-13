using System.IO;

namespace SolidPrinciples.ISP.Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../data/document1.xml");
            var targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../data/document1.json");

            var formatConverter = new FormatConverter();
            formatConverter.ConvertFormat(sourceFilePath, targetFilePath);
        }
    }
}
