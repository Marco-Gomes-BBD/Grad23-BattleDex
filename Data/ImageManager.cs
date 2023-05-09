using System.Text.Json;

namespace Grad23_BattleDex.Data
{
    internal record TaggedImage(string path, List<string> tags);

    internal class ImageManager
    {
        List<TaggedImage> images;
        public HashSet<string> tags;

        public ImageManager(string path)
        {
            tags = new();

            FileStream file = new(path, FileMode.Open, FileAccess.Read);
            List<TaggedImage>? images = JsonSerializer.Deserialize<List<TaggedImage>>(file);

            this.images = images ?? new List<TaggedImage>();
            foreach (TaggedImage image in this.images)
            {
                foreach (string tag in image.tags)
                {
                    string baseTag = Language.Stemmer.Stem(tag);
                    tags.Add(baseTag);
                }
            }
        }

        internal string[] AllTags()
        {
            return tags.ToArray();
        }

        internal IEnumerable<string> GetImagesByTag(string tag)
        {
            return images.Where(image => image.tags.Contains(tag))
                         .Select(image => image.path);
        }

        internal IEnumerable<string> GetImagesByTags(string[] tags)
        {
            return tags.SelectMany(tag => GetImagesByTag(tag));
        }

        internal static bool HasTags(TaggedImage image, string[] tags)
        {
            bool hasAny = false;

            foreach (var tag in tags)
            {
                hasAny |= image.tags.Contains(tag);
            }

            return true;
        }

        internal IEnumerable<string> GetNotInTags(string[] tags)
        {
            return images.Where(image => HasTags(image, tags)).Select(image => image.path);
        }
    }
}
