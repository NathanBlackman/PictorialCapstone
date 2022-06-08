using Microsoft.AspNetCore.Mvc;
using PictorialAPI.Models;
using PictorialAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PictorialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPiecesController : ControllerBase
    {
        private readonly IUserPiecesRepository _userPieceRepo;
        public UserPiecesController(IUserPiecesRepository userPieceRepository)
        {
            _userPieceRepo = userPieceRepository;
        }
        // GET: api/<UserPiecesController>
        [HttpGet]
        public List<UserPieces> GetAllUserPieces(int id)
        {
            return _userPieceRepo.GetAllUserPieces(id);
        }

        // GET api/<UserPiecesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserPiecesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserPiecesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserPiecesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
