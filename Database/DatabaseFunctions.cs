using System.Data.SqlClient;
using System.Text.Json;
namespace Grad23_BattleDex.Database
{
    public class DatabaseFunctions
    {

        private SqlConnection ConnectToDB()
        {
            String connectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=BattleDexDB; Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }


        private class TaggedImage
        {
            public String path { get; set; }
            public List<String> tags { get; set; }
        }

        public void insertImages(String imagesJson)
        {
            SqlConnection conn = ConnectToDB();
            conn.Open();
            List<TaggedImage> imageLines = JsonSerializer.Deserialize<List<TaggedImage>>(imagesJson);
            String imageInsert = "INSERT INTO dbo.images (file_path) SELECT @filepath " +
                                 "WHERE NOT EXISTS (SELECT * FROM dbo.images WHERE file_path = @filepath); " +
                                 "SELECT id FROM dbo.images WHERE file_path = @filepath";
            String tagInsert = "INSERT INTO dbo.tags (tag) SELECT @tag " +
                                "WHERE NOT EXISTS (SELECT * FROM dbo.tags WHERE tag = @tag); " +
                                "SELECT id FROM dbo.tags WHERE tag = @tag";
            String imagetagInsert = "INSERT INTO dbo.images_tags (image_id, tag_id) SELECT @image_id, @tag_id " +
                                    "WHERE NOT EXISTS (SELECT * FROM dbo.images_tags WHERE image_id = @image_id AND tag_id = @tag_id)";
            foreach (var item in imageLines)
            {
                int imageID;
                using (SqlCommand command = new SqlCommand(imageInsert, conn))
                {
                    command.Parameters.AddWithValue("@filepath", item.path.ToString());
                    imageID = Convert.ToInt32(command.ExecuteScalar());
                }
                List<int> tagIDs = new List<int>();
                foreach (var tag in item.tags)
                {
                    int tagID;
                    using (SqlCommand command = new SqlCommand(tagInsert, conn))
                    {
                        command.Parameters.AddWithValue("@tag", tag.ToString());
                        tagID = Convert.ToInt32(command.ExecuteScalar());
                    }
                    using (SqlCommand command = new SqlCommand(imagetagInsert, conn))
                    {
                        command.Parameters.AddWithValue("@image_id", imageID);
                        command.Parameters.AddWithValue("@tag_id", tagID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            conn.Close();
        }

        public List<String> AllExistingTags()
        {
            SqlConnection conn = ConnectToDB();
            conn.Open();
            String sql = "SELECT tag FROM dbo.tags";
            List<String> tags = new List<String>();
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tags.Add(reader.GetString(0));
                    }
                }
            }
            conn.Close();
            return tags;
        }

        public List<string> GetAllImages()
        {
            SqlConnection conn = ConnectToDB();
            conn.Open();
            String sql = "SELECT file_path FROM dbo.images";
            List<String> tags = new List<String>();
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tags.Add(reader.GetString(0));
                    }
                }
            }
            conn.Close();
            return tags;
        }

        public List<String> GetImagesForTag(List<String> tags, int number = 0)
        {
            SqlConnection conn = ConnectToDB();
            conn.Open();
            String sql = "SELECT ";
            if (number > 0)
            {
                sql += "TOP " + number;
            }
            sql += "file_path FROM images " +
                            "LEFT JOIN images_tags ON images.id = images_tags.image_id " +
                            "LEFT JOIN tags ON images_tags.tag_id = tags.id " +
                            "WHERE tags.tag = @tag";
            List<String> images = new List<String>();
            foreach (String tag in tags)
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@tag", tag);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (images.Count < number || number == 0)
                        {
                            images.Add(reader.GetString(0));                            
                        }
                    }
                    reader.Close();
                }
            }
            conn.Close();
            return images.Distinct().ToList();
        }
    }
}