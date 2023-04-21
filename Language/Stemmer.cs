using Porter2StemmerStandard;

namespace Grad23_BattleDex.Language
{
    internal class Stemmer
    {
        static readonly EnglishPorter2Stemmer stemmer = new();

        public static string Stem(string text)
        {
            return stemmer.Stem(text).Value;
        }
    }
}
