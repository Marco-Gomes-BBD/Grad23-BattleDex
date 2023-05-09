using System.Text.RegularExpressions;
using Grad23_BattleDex.Language;

namespace Grad23_BattleDex.Topics
{
    internal class TopicParser
    {
        public static string[] Parse(string topic)
        {
            Regex wordMatcher = new Regex(@"\w+");
            MatchCollection matches = wordMatcher.Matches(topic);

            IEnumerable<string> words = matches.Select(match => match.Value);
            IEnumerable<string> tags = words.Select(word => Stemmer.Stem(word));

            return tags.ToArray();
        }
    }
}
