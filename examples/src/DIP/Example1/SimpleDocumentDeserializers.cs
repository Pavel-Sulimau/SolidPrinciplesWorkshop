using System.Xml.Linq;

namespace SolidPrinciples.DIP.Example1
{
    public class SimpleDocumentDeserializer
    {
        public virtual SimpleDocument Deserialize(string input)
        {
            var xmlDocument = XDocument.Parse(input);
            return new SimpleDocument
            {
                Title = xmlDocument.Root.Element(nameof(SimpleDocument.Title).ToLower()).Value,
                Text = xmlDocument.Root.Element(nameof(SimpleDocument.Text).ToLower()).Value
            };
        }
    }

    public class TxtSimpleDocumentDeserializer : SimpleDocumentDeserializer
    {
        public override SimpleDocument Deserialize(string input)
        {
            // Let's asume we have parsed the data fron input stirng.
            return new SimpleDocument
            {
                Title = "Mock title",
                Text = "Mock text"
            };
        }
    }
}
