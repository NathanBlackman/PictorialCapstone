using PictorialAPI.Models;
using Microsoft.Data.SqlClient;

namespace PictorialAPI.Repositories
{
    public class UserPiecesRepository : IUserPiecesRepository
    {
        private readonly IConfiguration _config;
        public UserPiecesRepository(IConfiguration config)
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

        public List<UserPieces> GetAllUserPieces(int userId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id,
                               ArtistUserId,
                               PieceId
                        FROM UserPieces
                    ";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<UserPieces> userPieces = new List<UserPieces>();
                    while (reader.Read())
                    {
                        UserPieces userPiece = new UserPieces
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ArtistUserId = reader.GetInt32(reader.GetOrdinal("ArtistUserId")),
                            PieceId = reader.GetInt32(reader.GetOrdinal("PieceId")),

                        };
                        if (reader.IsDBNull(reader.GetOrdinal("ArtistUserId")) == false)
                        {
                            userPiece.ArtistUserId = reader.GetInt32(reader.GetOrdinal("ArtistUserId"));
                        }

                        userPieces.Add(userPiece);
                    }
                    reader.Close();

                    return userPieces;
                }
            }
        }

        public UserPieces GetSinglePiece(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id,
                               ArtistUserId,
                               PieceId
                        FROM UserPieces
                        WHERE Id = @id
                    ";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        UserPieces userPiece = new UserPieces
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ArtistUserId = reader.GetInt32(reader.GetOrdinal("ArtistUserId")),
                            PieceId = reader.GetInt32(reader.GetOrdinal("PieceId")),
                        };
                        if (reader.IsDBNull(reader.GetOrdinal("ArtistUserId")) == false)
                        {
                            userPiece.ArtistUserId = reader.GetInt32(reader.GetOrdinal("ArtistUserId"));
                        }

                        reader.Close();
                        return userPiece;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }
        public void AddUserPiece(UserPieces userPieces)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO UserPieces (ArtistUserId,
                                            PieceId,
                                            )
                    OUTPUT INSERTED.ID
                    VALUES (@name, @image, @date, @artistUserId)
                ";
                    /*cmd.Parameters.AddWithValue("@name", pieces.Name);
                    cmd.Parameters.AddWithValue("@image", pieces.Image);
                    cmd.Parameters.AddWithValue("@date", pieces.Date);*/

                    // int == false ///////////////////////////
                    if (userPieces.ArtistUserId == 0) 
                    {
                        cmd.Parameters.AddWithValue("@artistUserId", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@artistUserId", userPieces.ArtistUserId);
                    }

                    int newlyCreatedId = (int)cmd.ExecuteScalar();

                    userPieces.Id = newlyCreatedId;
                }
            }
        }
        public void UpdateUserPiece(UserPieces userPieces)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    UPDATE UserPieces
                    SET
                        ArtistUserId = @artistUserId
                        PieceId = @pieceId
                    WHERE Id = @id
                ";

                    /*cmd.Parameters.AddWithValue("@name", pieces.Name);
                    cmd.Parameters.AddWithValue("@image", pieces.Image);
                    cmd.Parameters.AddWithValue("@date", pieces.Date);
                    cmd.Parameters.AddWithValue("@id", pieces.Id);*/

                    if (userPieces.ArtistUserId == null) // int == false is wrong
                    {
                        cmd.Parameters.AddWithValue("@artistUserId", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@artistUserId", userPieces.ArtistUserId);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteUserPiece(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    DELETE FROM Pieces
                    WHERE Id = @id
                ";
                    cmd.Parameters.AddWithValue("id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}