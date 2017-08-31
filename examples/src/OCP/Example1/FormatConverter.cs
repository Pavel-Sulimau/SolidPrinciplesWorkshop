namespace SolidPrinciples.OCP.Example1
{
    public class FormatConverter
    {
        private readonly DataStorageBase _dataStorage;
        private readonly SimpleDocumentDeserializer _deserializer;
        private readonly ISimpleDocumentSerializer _serializer;

        public FormatConverter()
        {
            _dataStorage = new FileSystemDataStorage();
            _deserializer = new TxtSimpleDocumentDeserializer();
            _serializer = new CamelCaseJsonDocumentSerializer();
        }

        public void ConvertFormat(string sourceDataKey, string targetDataKey)
        {
            string simpleDocumentAsString = _dataStorage.GetData(sourceDataKey);

            var simpleDocument = _deserializer.Deserialize(simpleDocumentAsString);
            var simpleDocumentAsJson = _serializer.Serialize(simpleDocument);

            _dataStorage.SaveData(simpleDocumentAsJson, targetDataKey);
        }
    }
}
