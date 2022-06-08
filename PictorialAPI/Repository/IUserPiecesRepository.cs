using PictorialAPI.Models;

namespace PictorialAPI.Repositories
{
    public interface IUserPiecesRepository
    {
        // GetSinglePiece change in repo and controller
        List<UserPieces> GetAllUserPieces(int id);
        public UserPieces GetSinglePiece(int id);

        public void AddUserPiece(UserPieces userPieces);
        public void UpdateUserPiece(UserPieces userPieces);
        public void DeleteUserPiece(int id);
    }
}
