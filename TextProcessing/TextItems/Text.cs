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

        public List<Word> GetUniqueWordsFromQuestionSentences()
        {
            var words = new List<Word>();

            foreach (var sentence in Sentences)
            {
                if (sentence.Type == Enums.TypeSentence.Question)
                {
                    foreach (var word in sentence.Words)
                    {
                        words.Add(word);
                    }
                }
            }

            words = words.Distinct().ToList();

            return words;
        }

        public Text RemoveWordsWithFirstConsonantLetter(int wordLength)
        {
            char[] consonantUpperLetters = { 'Б', 'В', 'Г', 'Д', 'Ж', 'З', 'Й', 'К', 'Л', 'М', 'Н', 'П', 'Р', 'С', 'Т', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ' };
            char[] consonantLowerLetters = { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };

            for (int i = 0; i < Sentences.Count; ++i)
            {
                for (int j = 0; j < Sentences[i].Words.Count; ++j)
                {
                    var word = Sentences[i].Words[j].ToString();

                    for (int k = 0; k < consonantUpperLetters.Length; ++k)
                    {
                        if ((word[0] == consonantUpperLetters[k] ||
                             word[0] == consonantLowerLetters[k]) &&
                             word.Length == wordLength)
                        {
                            Sentences[i].Words.RemoveAt(j);
                        }
                    }
                }
            }

            return this;
        }

        public Sentence ChangeWordsTo(string changeWord, int wordLength, int sentenceId)
        {
            var sentence = Sentences[sentenceId - 1];

            for (int i = 0; i < sentence.Words.Count; ++i)
            {
                if (sentence.Words[i].ToString().Length == wordLength)
                {
                    sentence.Words[i] = new Word(changeWord);
                }
            }

            return sentence;
        }

        public override string ToString()
        {
            var textBuilder = new StringBuilder();
            foreach (var sentence in Sentences) textBuilder.Append(sentence.ToString());
            return textBuilder.ToString();
        }
    }
}
