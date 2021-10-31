using System.Collections.Generic;
using System.Text;

namespace TextProcessing.Concordance
{
    public class ConcordanceWord
    {
        public string Data { get; private set; }
        public int MeetingCount { get; internal set; }
        public List<int> ID { get; internal set; }

        public ConcordanceWord(string data, List<int> id, int meetingCount)
        {
            Data = data;
            ID = id;
            MeetingCount = meetingCount;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Data + ' ');
            for (int i = 0; i < 15 - Data.Length; i++) stringBuilder.Append('.');
            stringBuilder.Append($" {MeetingCount} :");
            for (int i = 0; i < ID.Count; ++i) stringBuilder.Append(" " + (ID[i] + 1));
            return stringBuilder.ToString();
        }
    }
}
