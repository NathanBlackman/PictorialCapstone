using PictorialAPI.Models;

namespace PictorialAPI.Repositories
{
    public interface IPieceRepository
    {
        public List<Pieces> GetAllPieces();
        public void AddPiece(Pieces piece);
        public void UpdatePiece(Pieces piece);
        public void DeletePiece(int id);
        public Pieces GetPieceById(int id);
    }
}
