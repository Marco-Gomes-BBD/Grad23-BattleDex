using Grad23_BattleDex.Database;
using System.Data;

namespace Grad23_BattleDex.SG
{
    public class SlideGenerator
    {
        private static readonly Random random = new();

        public static List<string> Generate(List<string> tags, int presentationSize)
        {
            List<string> dbTags = DatabaseFunctions.AllExistingTags()
                .Where(dbTag => Contains(dbTag, tags)).ToList();

            List<string> locations = DatabaseFunctions.GetImagesForTag(dbTags)
                .OrderBy(a => random.Next())
                .Take(presentationSize)
                .ToList();

            int remaining = presentationSize - locations.Count;

            if (remaining > 0)
            {
                locations.AddRange(
                    DatabaseFunctions.GetAllImages()
                    .Where(location => !locations.Contains(location))
                    .OrderBy(a => random.Next())
                    .Take(remaining)
                    .ToList());
            }

            return locations;
        }

        private static bool Contains(string dbTag, List<string> tags)
        {
            return tags.Select(dbTag.Contains).Any();
        }
    }
}