using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextProcessing.Concordance
{
    public class ConcordanceBuilder
    {
        private readonly List<string> _data;

        public List<ConcordanceString> ConcordanceStrings { get; private set; }

        public ConcordanceBuilder(string[] data)
        {
            _data = data.ToList();
            ConcordanceStrings = new List<ConcordanceString>(data.Length);

            foreach (var item in _data)
            {
                ConcordanceStrings.Add(new ConcordanceString(item, _data.IndexOf(item)));
            }
        }

        public List<string> CreateConcordance()
        {
            var concordance = new List<string>();

            var words = new Dictionary<int, ConcordanceWord>();
            var key = -1;
            foreach (var concordanceString in ConcordanceStrings)
            {
                foreach (var concordanceWord in concordanceString.ConcordanceWords)
                {
                    words.Add(++key, new ConcordanceWord(concordanceWord.Data, concordanceWord.ID));
                }
            }

            var allMeetings = new List<int>();

            var count = 0;
            var currentMeetings = new List<int>();
            var wordsCopy = new Dictionary<int, ConcordanceWord>(words);
            foreach (var currentWord in wordsCopy)
            {
                var wordsCopyValues = wordsCopy.Values.ToList();
                var currentIndex = wordsCopyValues.IndexOf(currentWord.Value);
                currentMeetings.Add(currentIndex);

                bool isMeetingIndex = false;
                foreach (var meeting in allMeetings)
                {
                    if (currentIndex == meeting) { isMeetingIndex = true; break; } 
                }

                if (!isMeetingIndex)
                {

                    foreach (var compareWord in wordsCopy)
                    {
                        var compareIndex = wordsCopyValues.IndexOf(compareWord.Value);

                        if (currentIndex > compareIndex && currentWord.Value.Data == compareWord.Value.Data)
                        {
                            ++count;
                            currentMeetings.Add(compareWord.Key);
                            allMeetings.Add(compareIndex);
                        }
                    }

                    currentMeetings.Distinct();

                    var stringBuilder = new StringBuilder();
                    stringBuilder.Append(currentWord.Value.Data + ' ');
                    for (int i = 0; i < 20 - currentWord.Value.Data.Length; ++i)
                    {
                        stringBuilder.Append('.');
                    }
                    stringBuilder.Append(' ');
                    stringBuilder.Append(count + 1);
                    stringBuilder.Append(": ");
                    stringBuilder.Append(string.Join(" ", currentWord.Value.ID));

                    concordance.Add(stringBuilder.ToString());
                }

                count = 0;
                currentMeetings = new List<int>();
            }

            return concordance;
        }
    }
}
