using PictorialAPI.Models;

namespace PictorialAPI.Repositories
{
    public interface IArtistUserRepository
    {
        public List<ArtistUser> GetAllArtists();
        public void AddArtist(ArtistUser artist);
        public void UpdateArtist(ArtistUser artist);
        public void DeleteArtist(string firebaseId);
        public ArtistUser GetByFirebaseId(string firebaseId);
    }
}
