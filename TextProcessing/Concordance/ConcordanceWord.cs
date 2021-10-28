namespace TextProcessing.Concordance
{
    public class ConcordanceWord
    {
        public string Data { get; private set; }
        public int ID { get; private set; }

        public ConcordanceWord(string data, int id)
        {
            Data = data;
            ID = id;
        }
    }
}
