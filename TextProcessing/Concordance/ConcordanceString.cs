using System.Collections.Generic;

namespace TextProcessing.Concordance
{
    public class ConcordanceString
    {
        public List<ConcordanceWord> ConcordanceWords { get; private set; }

        public ConcordanceString(string data, int id)
        {
            ConcordanceWords = TextParser.GetConcordanceWords(data, id);
        }
    }
}
