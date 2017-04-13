using Newtonsoft.Json;

namespace SolidPrinciples.SRP.Example1.SRP
{
    public class SimpleDocumentSerializer
    {
        public string SerializeToJson(SimpleDocument simpleDocument)
        {
            return JsonConvert.SerializeObject(simpleDocument);
        }
    }
}
