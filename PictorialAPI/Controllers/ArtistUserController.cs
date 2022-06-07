using Microsoft.AspNetCore.Mvc;
using PictorialAPI.Models;
using PictorialAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PictorialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistUserController : ControllerBase
    {
        private readonly IArtistUserRepository _artistUserRepo;
        public ArtistUserController(IArtistUserRepository artistUserRepository)
        {
            _artistUserRepo = artistUserRepository;
        }
        // GET: api/<ArtistUserController>
        [HttpGet]
        public List<ArtistUser> Get()
        {
            return _artistUserRepo.GetAllArtistUsers();
        }

        // GET api/<ArtistUserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArtistUserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArtistUserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArtistUserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
