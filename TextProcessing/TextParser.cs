using System.Collections.Generic;
using System.Linq;

using TextProcessing.TextItems;
using TextProcessing.Concordance;

namespace TextProcessing
{
    public static class TextParser
    {
        //TEXT ITEMS
        public static Text CreateText(string text) => new Text(text);
        public static Text CreateText(string[] text) => new Text(text);

        internal static List<Sentence> GetSentences(string text)
        {
            var sentences = new List<Sentence>();
            var words = new List<string>();

            if (!char.IsPunctuation(text.Last())) text += '.';

            var splittedWords = text.Split(' ');
            for (int i = 0; i < splittedWords.Length; ++i)
            {
                if (splittedWords[i].Contains('\t'))
                {
                    splittedWords[i] = string.Join("", splittedWords[i].Split('\t'));
                }
                if (splittedWords[i] != "") words.Add(splittedWords[i]);
            }

            var sentence = new List<string>();
            foreach (var word in words)
            {
                sentence.Add(word);
                if (word.Contains('.') || word.Contains('!') || word.Contains('?'))
                {
                    sentences.Add(new Sentence(string.Join(" ", sentence)));
                    sentence = new List<string>();
                }
            }

            return sentences;
        }

        internal static List<Word> GetWords(string sentence)
        {
            var words = new List<Word>();

            if (!char.IsPunctuation(sentence.Last())) sentence += '.';

            var splittedWords = sentence.Split(' ').ToList();
            foreach (var splittedWord in splittedWords)
            {
                words.Add(char.IsPunctuation(splittedWord.Last()) ? 
                    new Word(splittedWord.Remove(splittedWord.Length - 1)) :
                    new Word(splittedWord));
            }

            return words;
        }

        internal static Dictionary<int, PunctuationMark> GetPunctuationMarks(string sentence)
        {
            var punctuationMarks = new Dictionary<int, PunctuationMark>();

            var splittedWords = sentence.Split(' ').ToList();
            foreach (var splittedWord in splittedWords)
            {
                var lastSymbol = splittedWord.Last();
                if (char.IsPunctuation(lastSymbol))
                {
                    punctuationMarks.Add(splittedWords.IndexOf(splittedWord), new PunctuationMark(lastSymbol));
                }
            }

            return punctuationMarks;
        }

        internal static List<Symbol> GetSymbols(string word)
        {
            var symbols = new List<Symbol>();
            foreach (var symbol in word.ToCharArray()) symbols.Add(new Symbol(symbol));
            return symbols;
        }

        //CONCORDANCE
        internal static List<ConcordanceWord> GetWords(string[] data)
        {
            var listData = data.ToList();
            var concordanceWords = new List<ConcordanceWord>(listData.Count);

            foreach (var item in listData)
            {
                char[] separators = { ' ', ',', '.', '-', '(', ')', '!', '?', ':', ';', '\t' };
                var splittedWords = item.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
                foreach (var splittedWord in splittedWords)
                {
                    var id = new List<int> { listData.IndexOf(item) };
                    concordanceWords.Add(new ConcordanceWord(splittedWord.ToLower(), id, 0));
                }
            }

            return concordanceWords;
        }
    }
}
