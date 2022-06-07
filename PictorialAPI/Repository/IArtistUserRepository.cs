using PictorialAPI.Models;

namespace PictorialAPI.Repositories
{
    public interface IArtistUserRepository
    {
        public List<ArtistUser> GetAllArtistUsers();
        public void AddArtistUser(ArtistUser artist);
        public void UpdateArtistUser(ArtistUser artist);
        public void DeleteArtistUser(string firebaseId);
        public ArtistUser GetByFirebaseId(string firebaseId);
    }
}
