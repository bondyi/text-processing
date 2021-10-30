using System.Collections.Generic;
using System.Linq;

namespace TextProcessing.Concordance
{
    public class ConcordanceBuilder
    {
        public List<ConcordanceWord> Words { get; private set; }

        public ConcordanceBuilder(string[] data)
        {
            Words = TextParser.GetWords(data);
        }

        public List<string> CreateConcordance()
        {
            var uniqueWords = new List<string>();

            foreach (var word in Words)
            {
                uniqueWords.Add(word.Data);
            }
            uniqueWords = uniqueWords.Distinct().ToList();

            var concordance = new List<string>(uniqueWords.Count);
            var uniqueConcordanceWords = new List<ConcordanceWord>();

            foreach (var uniqueWord in uniqueWords)
            {
                uniqueConcordanceWords.Add(new ConcordanceWord(uniqueWord, new List<int>(), 0));
            }

            foreach (var uniqueWord in uniqueConcordanceWords)
            {
                foreach (var word in Words)
                {
                    if (uniqueWord.Data == word.Data)
                    {
                        uniqueWord.MeetingCount++;
                        uniqueWord.ID.Add(word.ID[0]);
                    }
                }

                uniqueWord.ID = uniqueWord.ID.Distinct().ToList();
                concordance.Add(uniqueWord.ToString());
            }
            concordance.Sort();

            List<string> finalConcordance = new List<string>();
            char firstSymbol = concordance[0][0];
            finalConcordance.Add(firstSymbol.ToString().ToUpper());

            foreach(var masseges in concordance)
            {
                if (masseges[0] != firstSymbol)
                {
                    finalConcordance.Add(" ");
                    firstSymbol = masseges[0];
                    finalConcordance.Add(firstSymbol.ToString().ToUpper());

                }
                finalConcordance.Add(" " + masseges);
            }

            return finalConcordance;
        }
    }
}
