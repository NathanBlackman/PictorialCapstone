using Microsoft.AspNetCore.Mvc;
using PictorialAPI.Repositories;
using PictorialAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace PictorialAPI.Controllers
{
    [ApiController]
    [Route("api/artistUsers")]
    public class ArtistUserController : Controller
    {
        private readonly IArtistUserRepository _auRepo;
        public ArtistUserController(IArtistUserRepository auRepository)
        {
            _auRepo = auRepository;
        }

        // Get: api/artistUsers
        [Authorize]
        [HttpGet]

        public List<ArtistUser> Get()
        {
            return _auRepo.GetAllArtists();
        }

        [Authorize]
        [HttpGet("FirebaseId")]

        public IActionResult GetByFirebaseId(string firebaseId)
        {
            var matchingArtistUser = _auRepo.GetByFirebaseId(firebaseId);
            if (matchingArtistUser == null)
            {
                return NotFound();
            }

            return Ok();
        }

        // POST api/artistUsers

        /*[HttpPost]
        public IActionResult Post(ArtistUser artistUser)
        {

        }*/

        //Patch

        [Authorize]
        [HttpPatch("{firebaseId}")]

        public IActionResult Put(string firebaseId, ArtistUser artistUser)
        {
            if (firebaseId != artistUser.FirebaseId)
            {
                return BadRequest();
            }

            var existingArtist = _auRepo.GetByFirebaseId(firebaseId);
            if (existingArtist == null)
            {
                return NotFound();
            }
            else
            {
                _auRepo.UpdateArtist(artistUser);
                return NoContent();
            }
        }
        //Delete ArtistUser
        [Authorize]
        [HttpDelete("{firebaseId}")]

        public IActionResult Delete(string firebaseId)
        {
            var matchingArtistUser = _auRepo.GetByFirebaseId(firebaseId);
            if (matchingArtistUser != null)
            {
                return NotFound();
            }
            else
            {
                _auRepo.DeleteArtist(matchingArtistUser.FirebaseId);
                return NoContent();
            }
        }
    }
}

