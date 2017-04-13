namespace SolidPrinciples.DIP.Example1
{
    public class FormatConverter
    {
        private readonly IDataRetriever _dataRetriever;
        private readonly SimpleDocumentDeserializer _deserializer;
        private readonly ISimpleDocumentSerializer _serializer;
        private readonly IDataPersister _dataPersister;

        public FormatConverter(
            IDataRetriever dataRetriever,
            SimpleDocumentDeserializer deserializer,
            ISimpleDocumentSerializer serializer,
            IDataPersister dataPersister)
        {
            _dataRetriever = dataRetriever;
            _deserializer = deserializer;
            _serializer = serializer;
            _dataPersister = dataPersister;
        }

        public void ConvertFormat(string sourceFileName, string targetFileName)
        {
            string simpleDocumentAsString = _dataRetriever.GetData(sourceFileName);

            var simpleDocument = _deserializer.Deserialize(simpleDocumentAsString);
            var simpleDocumentSerialized = _serializer.Serialize(simpleDocument);

            _dataPersister.SaveData(simpleDocumentSerialized, targetFileName);
        }
    }
}
