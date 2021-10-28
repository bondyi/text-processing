using System.Collections.Generic;

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
    }
}
