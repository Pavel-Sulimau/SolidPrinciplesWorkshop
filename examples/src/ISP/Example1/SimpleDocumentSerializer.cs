using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SolidPrinciples.ISP.Example1
{
    public interface ISimpleDocumentSerializer
    {
        string Serialize(SimpleDocument simpleDocument);
    }

    public class JsonDocumentSerializer : ISimpleDocumentSerializer
    {
        public string Serialize(SimpleDocument simpleDocument)
        {
            return JsonConvert.SerializeObject(simpleDocument);
        }
    }

    public class CamelCaseJsonDocumentSerializer : ISimpleDocumentSerializer
    {
        public string Serialize(SimpleDocument simpleDocument)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.SerializeObject(simpleDocument, settings);
        }
    }
}
