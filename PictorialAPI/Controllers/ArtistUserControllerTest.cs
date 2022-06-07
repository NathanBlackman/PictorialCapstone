using Microsoft.AspNetCore.Mvc;
using PictorialAPI.Repositories;
using PictorialAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace PictorialAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistUserControllerTest : ControllerBase
    {
        private readonly IArtistUserRepository _artistUserRepo;
        public ArtistUserControllerTest(IArtistUserRepository artistUserRepository)
        {
            _artistUserRepo = artistUserRepository;
        }

        // Get: api/artistUsers
        [Authorize]
        [HttpGet]
        public List<ArtistUser> Get()
        {
            return _artistUserRepo.GetAllArtistUsers();
        }

        [Authorize]
        [HttpGet("{firebaseId}")]

        public IActionResult GetByFirebaseId(string firebaseId)
        {
            var matchingArtistUser = _artistUserRepo.GetByFirebaseId(firebaseId);
            if (matchingArtistUser == null)
            {
                return NotFound();
            }

            return Ok(matchingArtistUser);
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

            var existingArtist = _artistUserRepo.GetByFirebaseId(firebaseId);
            if (existingArtist == null)
            {
                return NotFound();
            }
            else
            {
                _artistUserRepo.UpdateArtistUser(artistUser);
                return NoContent();
            }
        }
        //Delete ArtistUser
        [Authorize]
        [HttpDelete("{firebaseId}")]

        public IActionResult Delete(string firebaseId)
        {
            var matchingArtistUser = _artistUserRepo.GetByFirebaseId(firebaseId);
            if (matchingArtistUser != null)
            {
                return NotFound();
            }
            else
            {
                _artistUserRepo.DeleteArtistUser(matchingArtistUser.FirebaseId);
                return NoContent();
            }
        }
    }
}

