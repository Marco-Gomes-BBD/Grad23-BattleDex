using System;
using System.CodeDom;
using System.Data;
using System.Data.SqlClient;

namespace Grad23_BattleDex.SG
{

    public class SlideGenerator
    {
        private const string query = "SELECT DISTINC(IMAGES.file_path)" +
                        "FROM images_tags " +
                        "INNER JOIN tags ON tags.id = images_tags.tag_id " +
                        "INNER JOIN images ON images.id = images_tags.image_id" +
                        "WHERE TAGS.tag IN @tags";
        private static Random random = new Random();

        public static List<string> Generate(List<string> tags, int presentationSize, SqlConnection connection)
        {
            List<string> locations = GetImageLocations(tags, connection)
                .OrderBy(a => random.Next())
                .Take(presentationSize)
                .ToList();
            return locations;
        }

        private static List<string> GetImageLocations(List<string> tags, SqlConnection connection)
        {
            List<string> locations = new List<string>();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@tags", tags);
            try
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read()) 
                {
                    locations.Add(reader.GetString(0));
                }
                reader.Close();
            } catch (Exception ex)
            {
                // TODO do something with the error
                Console.WriteLine(ex.ToString());
            }
            return locations;
        }

    }

}