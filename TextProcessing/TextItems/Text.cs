using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextProcessing.TextItems
{
    public class Text
    {
        public List<Sentence> Sentences { get; private set; }

        internal Text(string text)
        {
            Sentences = TextParser.GetSentences(text);
        }

        internal Text(string[] text) : this(string.Join(" ", text)) { }

        public override string ToString()
        {
            var textBuilder = new StringBuilder();
            foreach (var sentence in Sentences) textBuilder.Append(sentence.ToString());
            return textBuilder.ToString();
        }

        public List<Sentence> SortByWordCount()
        {
            var sentences = new List<Sentence>(Sentences.Count);
            var wordsCounts = new List<int>(Sentences.Count);

            foreach (var sentence in Sentences)
            {
                wordsCounts.Add(sentence.Words.Count);
            }
            wordsCounts.Sort();

            foreach (var wordCount in wordsCounts)
            {
                foreach (var sentence in Sentences)
                {
                    if (wordCount == sentence.Words.Count) sentences.Add(sentence);
                }
            }

            return sentences.Distinct().ToList();
        }


    }
}
