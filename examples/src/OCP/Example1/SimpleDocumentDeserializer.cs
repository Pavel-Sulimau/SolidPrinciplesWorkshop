using System.Xml.Linq;

namespace SolidPrinciples.OCP.Example1
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
            // ToDo: parse title from the first string, parse text from the second
            return new SimpleDocument
            {
                Title = "Mock title",
                Text = "Mock text"
            };
        }
    }
}
