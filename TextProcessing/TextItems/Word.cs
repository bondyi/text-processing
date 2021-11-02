using System.Collections.Generic;
using System.Text;

namespace TextProcessing.TextItems
{
    public class Word
    {
        public List<Symbol> Symbols { get; private set; }

        internal Word(string word)
        {
            Symbols = TextParser.GetSymbols(word);
        }

        public override string ToString()
        {
            var wordBuilder = new StringBuilder();
            foreach (var symbol in Symbols) wordBuilder.Append(symbol.ToString());
            return wordBuilder.ToString();
        }
    }
}
