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
        private readonly IUserPiecesRepository _upRepo;
        private readonly UserPiecesRepository _userPieceRepo;

        // GET api/<UserPiecesController>
        public UserPiecesController(IUserPiecesRepository userPieceRepository)
        {
            _upRepo = userPieceRepository;
        }

        [HttpGet]
        public List<UserPieces> GetAllUserPieces()
        {
            return _upRepo.GetAllUserPieces();
        }

        // GET api/<UserPiecesController>/{id}
        [HttpGet("{id}")]
        public Pieces Get(int id)
        {
            return _upRepo.GetUserPieceById(id);
        }

        // POST api/<UserPiecesController>
        [HttpPost]
        public IActionResult Post(UserPieces newUserPiece)
        {
            _piecesRepo.AddPiece(newUserPiece);
            return Ok(newUserPiece);
        }
        
        // PATCH api/<UserPiecesController>/{id}
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPatch("{id}")]
        public IActionResult Put(int id, UserPieces userPieces)
        {
            if (id != UserPieces.Id)
            {
                return BadRequest();
            }
            var existingUserPiece = _upRepo.GetUserPiecesById(id);
            if (existingUserPiece == null)
            {
                return NotFound();
            }
            else
            {
                _upRepo.UpdateUserPiece(userPieces);
                return NoContent();
            }
        }
        
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var matchingUserPiece = _upRepo.GetUserPieceById(id);
            if(matchingUserPiece == null)
            {
                return NotFound();
            }
            else
            {
                _upRepo.DeleteUserPiece(matchingUserPiece.Id);
                return NoContent();
            }
        }

        public Pieces GetUserPieceById(int id)
        {
            return _upRepo.GetUserPieceById(id);
        }
    }
}

