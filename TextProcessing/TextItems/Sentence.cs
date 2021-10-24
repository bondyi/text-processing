using System.Collections.Generic;
using System.Text;

namespace TextProcessing
{
    public class Sentence : TextComponent
    {
        public List<Word> Words { get; private set; }
        public Dictionary<int, PunctuationMark> PunctuationMarks { get; private set; }
        public TypeSentence Type { get; private set; }
        
        public Sentence(string sentence) : base(sentence)
        {
            Words = TextParser.ParseSentence(sentence);
            PunctuationMarks = TextParser.GetPunctuationMarks(sentence);
            Type = GetType();
        }

        new private TypeSentence GetType()
        {
            switch (PunctuationMarks[Words.Count - 1].Type)
            {
                case TypeSymbol.Point: return TypeSentence.Narration;
                case TypeSymbol.ExclamationPoint: return TypeSentence.Exclamation;
                case TypeSymbol.QuestionPoint: return TypeSentence.Question;
                default: return TypeSentence.Unknown;
            }
        }

        public override string ToString()
        {
            var sentenceBuilder = new StringBuilder();
            foreach (var word in Words)
            {
                sentenceBuilder.Append(word.ToString());
                foreach (var punctuationMark in PunctuationMarks)
                {
                    if (Words.IndexOf(word) == punctuationMark.Key) sentenceBuilder.Append(punctuationMark.Value);
                }
                sentenceBuilder.Append(' ');
            }

            return sentenceBuilder.ToString();
        }
    }
}
