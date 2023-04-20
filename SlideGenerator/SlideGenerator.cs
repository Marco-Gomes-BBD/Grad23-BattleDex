using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Grad23_BattleDex.SG
{

    public class SlideGenerator
    {
        private const string query = "SELECT DISTINC(IMAGES.file_path)" +
                        "FROM images_tags " +
                        "INNER JOIN tags ON tags.id = images_tags.tag_id " +
                        "INNER JOIN images ON images.id = images_tags.image_id" +
                        "WHERE TAGS.tag IN @tags";
        private static Random random = new();

        public static List<string> Generate(List<string> tags, int presentationSize, SqlConnection connection)
        {
            return GetImageLocations(tags, connection)
                .OrderBy(a => random.Next())
                .Take(presentationSize)
                .ToList();
        }

        private static List<string> GetImageLocations(List<string> tags, SqlConnection connection)
        {
            SqlCommand sqlCommand = new(query, connection);
            sqlCommand.Parameters.AddWithValue("@tags", tags);
            try
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();
                List<string> locations = GetEnumerable(reader).ToList();
                reader.Close();
                return locations;
            } catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            return new List<string>();
        }

        private static IEnumerable<string> GetEnumerable(SqlDataReader reader)
        {
            while (reader.Read())
            {
                yield return reader.GetString(0);
            }
        }

    }

}