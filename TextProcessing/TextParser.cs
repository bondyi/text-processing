using System.Collections.Generic;
using System.Linq;

namespace TextProcessing
{
    public static class TextParser
    {
        public static List<Sentence> ParseText(string text)
        {
            var words = new List<string>();
            var sentences = new List<Sentence>();

            var lastSymbol = text.Last();
            if (lastSymbol != '.' && lastSymbol != '!' && lastSymbol != '?') text += '.';

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

        public static List<Word> ParseSentence(string sentence)
        {
            var words = new List<Word>();

            foreach (var splittedWord in sentence.Split(' '))
            {
                if (char.IsPunctuation(splittedWord.Last()))
                {
                    words.Add(new Word(splittedWord.Remove(splittedWord.Length - 1, 1)));
                }
                else words.Add(new Word(splittedWord));
            }

            return words;
        }

        public static Dictionary<int, PunctuationMark> GetPunctuationMarks(string sentence)
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

        public static List<Symbol> ParseWord(string word)
        {
            var symbols = new List<Symbol>();
            foreach (var symbol in word.ToCharArray())
            {
                symbols.Add(new Symbol(symbol));
            }

            return symbols;
        }
    }
}
