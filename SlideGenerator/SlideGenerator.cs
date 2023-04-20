using Grad23_BattleDex.Database;
using System.Data;

namespace Grad23_BattleDex.SG
{

    public class SlideGenerator
    {
        private static Random random = new();

        public static List<string> Generate(List<string> tags, int presentationSize)
        {
            DatabaseFunctions databaseFunctions = new DatabaseFunctions();
            List<string> dbTags = databaseFunctions.AllExistingTags()
                .Where(dbTag => Contains(dbTag, tags)).ToList();


            return databaseFunctions.GetImagesForTag(dbTags)
                .OrderBy(a => random.Next())
                .Take(presentationSize)
                .ToList();
        }

        private static Boolean Contains(string dbTag, List<String> tags)
        {
            return tags.Select(tag => tag.Contains(dbTag)).Any();
        }

    }

}