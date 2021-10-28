using System.Collections.Generic;
using System.Text;

namespace TextProcessing.Concordance
{
    public class ConcordanceString
    {
        public ConcordanceWord Word;

        public ConcordanceString(string data, List<int> id, int meetingCount)
        {
            Word = new ConcordanceWord(data, id, meetingCount);
        }

        public ConcordanceString(ConcordanceWord word) => Word = word;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Word.Data + ' ');
            for (int i = 0; i < 15 - Word.Data.Length; i++) stringBuilder.Append('.');
            stringBuilder.Append($" {Word.MeetingCount} : ");
            for (int i = 0; i < Word.ID.Count; ++i) Word.ID[i] += 1;
            stringBuilder.Append(string.Join(" ", Word.ID));
            return stringBuilder.ToString();
        }
    }
}
