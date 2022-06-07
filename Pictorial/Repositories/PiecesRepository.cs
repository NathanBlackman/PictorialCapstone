using PictorialAPI.Models;
using Microsoft.Data.SqlClient;

namespace PictorialAPI.Repositories
{
    public class PiecesRepository : IPiecesRepository
    {
        private readonly IConfiguration _config;
        public PiecesRepository(IConfiguration config)
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

        public List<Pieces> GetAllPieces()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id,
                               [Name],
                               [Image],
                               [Date],
                               ArtistUserId
                        FROM Pieces
                    ";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Pieces> pieces = new List<Pieces>();
                    while (reader.Read())
                    {
                        Pieces piece = new Pieces
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Image = reader.GetString(reader.GetOrdinal("Image")),
                            Date = reader.GetString(reader.GetOrdinal("Date"))

                        };
                        if (reader.IsDBNull(reader.GetOrdinal("ArtistUserId")) == false)
                        {
                            piece.ArtistUserId = reader.GetInt32(reader.GetOrdinal("ArtistUserId"));
                        }

                        pieces.Add(piece);
                    }
                    reader.Close();

                    return pieces;
                }
            }
        }

        public Pieces GetPieceById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id,
                               [Name],
                               [Image],
                               [Date],
                               ArtistUserId
                        FROM Pieces
                        WHERE Id = @id
                    ";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Pieces pieces = new Pieces
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Image = reader.GetString(reader.GetOrdinal("Image")),
                            Date = reader.GetString(reader.GetOrdinal("Date")),
                        };
                        if (reader.IsDBNull(reader.GetOrdinal("ArtistUserId")) == false)
                        {
                            pieces.ArtistUserId = reader.GetInt32(reader.GetOrdinal("ArtistUserId"));
                        }

                        reader.Close();
                        return pieces;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }
        public void AddPiece(Pieces pieces)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Pieces ([Name], 
                                        [Image],
                                        [Date],
                                        ArtistUserId,
                                       )
                    OUTPUT INSERTED.ID
                    VALUES (@name, @image, @date, @artistUserId)
                ";
                    cmd.Parameters.AddWithValue("@name", pieces.Name);
                    cmd.Parameters.AddWithValue("@image", pieces.Image);
                    cmd.Parameters.AddWithValue("@date", pieces.Date);

                    if (pieces.ArtistUserId == 0)
                    {
                        cmd.Parameters.AddWithValue("@artistUserId", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@artistUserId", pieces.ArtistUserId);
                    }

                    int newlyCreatedId = (int)cmd.ExecuteScalar();

                    pieces.Id = newlyCreatedId;
                }
            }
        }
        public void UpdatePiece(Pieces pieces)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    UPDATE Pieces
                    SET
                        [Name] = @name,
                        [Image] = @image,
                        [Date] = @date,
                        ArtistUserId = @artistUserId
                    WHERE Id = @id
                ";

                    cmd.Parameters.AddWithValue("@name", pieces.Name);
                    cmd.Parameters.AddWithValue("@image", pieces.Image);
                    cmd.Parameters.AddWithValue("@date", pieces.Date);
                    cmd.Parameters.AddWithValue("@id", pieces.Id);

                    if (pieces.ArtistUserId == 0)
                    {
                        cmd.Parameters.AddWithValue("@artistUserId", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@artistUserId", pieces.ArtistUserId);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeletePiece(int id)
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