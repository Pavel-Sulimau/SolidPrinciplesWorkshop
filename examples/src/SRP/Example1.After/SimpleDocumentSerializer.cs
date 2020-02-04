using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SolidPrinciples.SRP.Example1.After
{
    public class SimpleDocumentSerializer
    {
        public string SerializeToJson(SimpleDocument simpleDocument)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.SerializeObject(simpleDocument, settings);
        }
    }
}
