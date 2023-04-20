using System.Data.SqlClient;
using System.Text.Json;
namespace Grad23_BattleDex;

public partial class BattleDex : Form
{
    public BattleDex()
    {
        InitializeComponent();
        String imageJson = @"[
                {
                    ""path"": ""example.png"",
                    ""tags"": [""example"", ""image""]
                },
                {
                    ""path"": ""dog.png"",
                    ""tags"": [""nose"", ""fluffy"", ""grass""]
                },
                {
                    ""path"": ""cat.png"",
                    ""tags"": [""nose"", ""ears"", ""tail""]
                }
            ]";
        insertImages(imageJson);
    }

    private SqlConnection ConnectToDB()
    {
        String connectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=BattleDexDB; Integrated Security=True";
        SqlConnection conn = new SqlConnection(connectionString);
        return conn;
    }


    public class Image
    {
        public String path { get; set; }
        public List<String> tags { get; set; }
    }

    private void insertImages(String imagesJson)
    {
        SqlConnection conn = ConnectToDB();
        conn.Open();
        List<Image> imageLines = JsonSerializer.Deserialize<List<Image>>(imagesJson);
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
}
