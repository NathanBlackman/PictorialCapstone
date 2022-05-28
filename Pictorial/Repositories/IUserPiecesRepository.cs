using PictorialAPI.Models;

namespace PictorialAPI.Repositories
{
    public interface IUserPiecesRepository
    {
        List<UserPieces> GetAllUserPieces();
        Pieces GetUserPieceById(int id);
    }
}
