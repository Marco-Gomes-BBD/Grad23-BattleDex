using System.Data;
using Grad23_BattleDex.Data;

namespace Grad23_BattleDex.Deck;

internal class DeckGenerator
{
    private static readonly Random random = new();

    public static List<string> Generate(ImageManager images, List<string> tags, int presentationSize)
    {
        string[] registeredTags = images.AllTags();
        string[] queryTags = registeredTags.Where(tags.Contains).ToArray();

        List<string> slides = images.GetImagesByTags(queryTags)
            .OrderBy(image => random.Next())
            .Take(presentationSize)
            .ToList();

        int remaining = presentationSize - slides.Count;

        if (remaining > 0)
        {
            slides.AddRange(
                images.GetNotInTags(queryTags)
                .Where(location => !slides.Contains(location))
                .OrderBy(a => random.Next())
                .Take(remaining)
                .ToList());
        }

        return slides;
    }
}
