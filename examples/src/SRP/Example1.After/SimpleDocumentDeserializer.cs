using System.Xml.Linq;

namespace SolidPrinciples.SRP.Example1.SRP
{
    public class SimpleDocumentDeserializer
    {
        public SimpleDocument DeserializeFromXml(string xml)
        {
            var xmlDocument = XDocument.Parse(xml);
            return new SimpleDocument
            {
                Title = xmlDocument.Root.Element(nameof(SimpleDocument.Title).ToLower()).Value,
                Text = xmlDocument.Root.Element(nameof(SimpleDocument.Text).ToLower()).Value
            };
        }
    }
}
