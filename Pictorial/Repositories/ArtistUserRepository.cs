using PictorialAPI.Models;
using Microsoft.Data.SqlClient;

namespace PictorialAPI.Repositories
{
    
    public class ArtistUserRepository
    {

        private readonly IConfiguration _config;

        public ArtistUserRepository(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<ArtistUsers> GetAllArtistUsers()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id,
                                               FirebaseId,
                                               [Name],
                                               [Image]
                                        FROM ArtistUser";

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ArtistUser> artistUsers = new List<ArtistUser>();
                    while (reader.Read())
                    {
                        ArtistUser artistUser = new ArtistUser;
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirebaseId = reader.GetInt32(reader.GetOrdinal("FirebaseId")),
                            Name = reader.GetInt32(reader.GetOrdinal("Name")),
                            Image = reader.GetInt32(reader.GetOrdinal("Image"))
                        };

                        artistUsers.Add(artistUser);
                    }

                    reader.Close();

                    Console.WriteLine(artistUser);
                    return artistUsers;
                }
            }
        }

        public ArtistUser GetByFirebaseId(string firebaseId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id,
                                               FirebaseId,
                                               [Name],
                                               [Image]
                                        FROM ArtistUser
                                        WHERE FirebaseId = @firebaseId";

                    cmd.Parameters.AddWithValue("@firebaseId", firebaseId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ArtistUser artistUser = new ArtistUser();
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirebaseUserId = reader.GetString(reader.GetOrdinal("FirebaseUserId")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Image = reader.GetString(reader.GetOrdinal("Image"))
                        };

                        reader.Close();
                        return artistUser;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public void AddArtist(ArtistUser artistUser)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Buyer (FirebaseUserId, [Name], UserName, Email, About, Image, [Role])
                    OUTPUT INSERTED.ID
                    VALUES (@firebaseUserId, @name, @userName, @email, @about, @image, @role);
                ";

                    cmd.Parameters.AddWithValue("@firebaseId", artistUser.FirebaseId);
                    cmd.Parameters.AddWithValue("@name", artistUser.Name);
                    cmd.Parameters.AddWithValue("@image", artistUser.Image);

                    int id = (int)cmd.ExecuteScalar();

                    artistUser.Id = id;
                }
            }
        }

        public void UpdateArtistUser(ArtistUser artistUser)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            UPDATE ArtistUser
                            SET 
                                [Name] = @name,
                                Image = @image,
                            WHERE FirebaseUserId = @firebaseUserId";

                    cmd.Parameters.AddWithValue("@firebaseId", artistUser.FirebaseUserId);
                    cmd.Parameters.AddWithValue("@name", artistUser.Name);
                    cmd.Parameters.AddWithValue("@image", artistUser.Image);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteArtistUser(string firebaseId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            DELETE FROM ArtistUser
                            WHERE FirebaseId = @firebaseId
                        ";

                    cmd.Parameters.AddWithValue("@firebaseId", firebaseId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

