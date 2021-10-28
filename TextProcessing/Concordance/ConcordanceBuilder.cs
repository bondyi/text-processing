using System.Collections.Generic;
using System.Linq;

namespace TextProcessing.Concordance
{
    public class ConcordanceBuilder
    {
        public List<ConcordanceString> ConcordanceStrings { get; private set; }

        public ConcordanceBuilder(string[] data)
        {
            ConcordanceStrings = TextParser.GetConcordanceStrings(data);
        }

        public List<string> CreateConcordance()
        {
            var uniqueWords = new List<string>();
            foreach (var concordanceString in ConcordanceStrings)
            {
                uniqueWords.Add(concordanceString.Word.Data);
            }

            uniqueWords = uniqueWords.Distinct().ToList();

            var concordance = new List<string>(uniqueWords.Count);
            var uniqueConcordanceStrings = new List<ConcordanceString>();
            foreach (var uniqueWord in uniqueWords)
            {
                uniqueConcordanceStrings.Add(new ConcordanceString(uniqueWord, new List<int>(), 0));
            }

            foreach (var uniqueConcordanceString in uniqueConcordanceStrings)
            {
                foreach (var concordanceString in ConcordanceStrings)
                {
                    if (uniqueConcordanceString.Word.Data == concordanceString.Word.Data)
                    {
                        uniqueConcordanceString.Word.MeetingCount++;
                        uniqueConcordanceString.Word.ID.Add(concordanceString.Word.ID[0]);
                    }
                }

                uniqueConcordanceString.Word.ID = uniqueConcordanceString.Word.ID.Distinct().ToList();
                concordance.Add(uniqueConcordanceString.ToString());
            }

            concordance.Sort();

            return concordance;
        }
    }
}
