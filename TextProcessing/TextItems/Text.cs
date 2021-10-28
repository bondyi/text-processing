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
            foreach (var sentence in Sentences) textBuilder.Append(sentence.ToString() + ' ');
            return textBuilder.ToString();
        }

        public List<Sentence> SortByWordCount()
        {
            var sortedSentences = new SortedList<int, Sentence>(Sentences.Count);
            foreach (var sentence in Sentences) sortedSentences.Add(sentence.Words.Count, sentence);
            return sortedSentences.Values.ToList();
        }
    }
}
