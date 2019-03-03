namespace SolidPrinciples.ISP.Example1
{
    public class FormatConverter
    {
        private readonly IDataRetriever _dataRetriever;
        private readonly SimpleDocumentDeserializer _deserializer;
        private readonly ISimpleDocumentSerializer _serializer;
        private readonly IDataPersister _dataPersister;

        public FormatConverter()
        {
            _dataRetriever = new FileSystemStorage();
            _deserializer = new SimpleDocumentDeserializer();
            _serializer = new CamelCaseJsonDocumentSerializer();
            _dataPersister = new FileSystemStorage();
        }

        public void Convert(string sourceFileName, string targetFileName)
        {
            string simpleDocumentAsString = _dataRetriever.GetData(sourceFileName);

            var simpleDocument = _deserializer.Deserialize(simpleDocumentAsString);
            var simpleDocumentSerialized = _serializer.Serialize(simpleDocument);

            _dataPersister.SaveData(simpleDocumentSerialized, targetFileName);
        }
    }
}
