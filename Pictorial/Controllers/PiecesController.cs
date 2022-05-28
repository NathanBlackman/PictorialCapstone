using PictorialAPI.Models;
using PictorialAPI.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace PictorialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiecesController : Controller
    {
        private readonly IPieceRepository _piecesRepo;

        // GET api/<PiecesController>
        public PiecesController(IPieceRepository pieceRepository)
        {
            _piecesRepo = pieceRepository;
        }

        [HttpGet]
        public List<Pieces> GetAllPieces()
        {
            return _piecesRepo.GetAllPieces();
        }

        // GET api/<PiecesController>/{id}
        [HttpGet("{id}")]
        public Pieces Get(int id)
        {
            return _piecesRepo.GetPieceById(id);
        }

        // POST api/<PiecesController>
        [HttpPost]
        public IActionResult Post(Pieces newPiece)
        {
            _piecesRepo.AddPiece(newPiece);
            return Ok(newPiece);
        }
        
        // PATCH api/<PieceController>/{id}
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPatch("{id}")]
        public IActionResult Put(int id, Pieces pieces)
        {
            if (id != pieces.Id)
            {
                return BadRequest();
            }
            var existingPiece = _piecesRepo.GetPieceById(id);
            if (existingPiece == null)
            {
                return NotFound();
            }
            else
            {
                _piecesRepo.UpdatePiece(pieces);
                return NoContent();
            }
        }
        
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var matchingPiece = _piecesRepo.GetPieceById(id);
            if(matchingPiece == null)
            {
                return NotFound();
            }
            else
            {
                _piecesRepo.DeletePiece(matchingPiece.Id);
                return NoContent();
            }
        }
    }
}
