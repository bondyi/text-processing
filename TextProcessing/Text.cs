using System.Collections.Generic;
using System.Text;

namespace TextProcessing
{
    public class Text : TextComponent
    {
        public List<Sentence> Sentences { get; private set; }

        public Text(string text) : base(text) => Sentences = TextParser.ParseText(text);

        public override string ToString()
        {
            var textBuilder = new StringBuilder();
            foreach (var sentence in Sentences)
            {
                textBuilder.Append(sentence.ToString() + ' ');
            }

            return textBuilder.ToString();
        }
    }
}
