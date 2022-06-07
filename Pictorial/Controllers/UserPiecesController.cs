using PictorialAPI.Models;
using PictorialAPI.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace PictorialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPiecesController : Controller
    {

        private readonly UserPiecesRepository _userPieceRepo;
        // add pieceRepo
        /*private readonly PiecesRepository _pieceRepo;*/


        // GET api/<UserPiecesController>
        public UserPiecesController(UserPiecesRepository userPieceRepository)
        {
            _userPieceRepo = userPieceRepository;
        }

        [HttpGet]
        public List<UserPieces> GetAllUserPieces(int id)
        {
            return _userPieceRepo.GetAllUserPieces(id);
        }

        // GET api/<UserPiecesController>/{id}
        [HttpGet("{id}")]
        public UserPieces GetSinglePiece(int id)
        {
            return _userPieceRepo.GetSinglePiece(id);
        }

        // POST api/<UserPiecesController>
        [HttpPost]
        public IActionResult Post(UserPieces newUserPiece)
        {
            _userPieceRepo.AddUserPiece(newUserPiece);
            return Ok(newUserPiece);
        }
        
        // PATCH api/<UserPiecesController>/{id}
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPatch("{id}")]
        public IActionResult Put(int id, UserPieces userPieces)
        {
            if (id != userPieces.Id)
            {
                return BadRequest();
            }
            var existingUserPiece = _userPieceRepo.GetSinglePiece(id);
            if (existingUserPiece == null)
            {
                return NotFound();
            }
            else
            {
                _userPieceRepo.UpdateUserPiece(userPieces);
                return NoContent();
            }
        }
        
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var matchingUserPiece = _userPieceRepo.GetSinglePiece(id);
            if(matchingUserPiece == null)
            {
                return NotFound();
            }
            else
            {
                _userPieceRepo.DeleteUserPiece(matchingUserPiece.Id);
                return NoContent();
            }
        }
    }
}

