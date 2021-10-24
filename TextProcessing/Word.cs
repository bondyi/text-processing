using System.Collections.Generic;
using System.Text;

namespace TextProcessing
{
    public class Word : TextComponent
    {
        public List<Symbol> Symbols { get; private set; }

        public Word(string word) : base(word) => Symbols = TextParser.ParseWord(word);

        public override string ToString()
        {
            var wordBuilder = new StringBuilder();
            foreach (var symbol in Symbols)
            {
                wordBuilder.Append(symbol);
            }

            return wordBuilder.ToString();
        }
    }
}
