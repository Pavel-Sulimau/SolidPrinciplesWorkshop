namespace SolidPrinciples.SRP.Example1.SRP
{
    public class FormatConverter
    {
        private readonly FileSystemStorage _fileSystemStorage;
        private readonly SimpleDocumentDeserializer _deserializer;
        private readonly SimpleDocumentSerializer _serializer;

        public FormatConverter()
        {
            _fileSystemStorage = new FileSystemStorage();
            _deserializer = new SimpleDocumentDeserializer();
            _serializer = new SimpleDocumentSerializer();
        }

        public void Convert(string sourceFilePath, string targetFilePath)
        {
            string simpleDocumentAsXml = _fileSystemStorage.GetData(sourceFilePath);
            var simpleDocument = _deserializer.DeserializeFromXml(simpleDocumentAsXml);
            var simpleDocumentAsJson = _serializer.SerializeToJson(simpleDocument);
            _fileSystemStorage.SaveData(simpleDocumentAsJson, targetFilePath);
        }
    }
}
