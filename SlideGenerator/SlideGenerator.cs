namespace Grad23_BattleDex.SlideGenerator
{

    public class SlideGenerator
    {

        private static Random random = new Random();

        public List<Bitmap> Generate(List<string> tags, int presentationSize)
        {
            List<Bitmap> locations = GetImageLocations(tags)
                .OrderBy(a => random.Next())
                .Take(presentationSize)
                .Select(GetImage)
                .ToList();
            return locations;
        }

        private List<string> GetImageLocations(List<string> tags)
        {

        }

        private Bitmap GetImage(string fileLocations)
        {
            return new Bitmap(fileLocations);
        }




    }

}