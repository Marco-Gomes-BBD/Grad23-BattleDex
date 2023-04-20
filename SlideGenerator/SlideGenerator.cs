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
            return databaseFunctions.GetImagesForTags(tags)
                .OrderBy(a => random.Next())
                .Take(presentationSize)
                .ToList();
        }

    }

}