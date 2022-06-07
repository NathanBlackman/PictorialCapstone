using Microsoft.AspNetCore.Mvc;
using PictorialAPI.Models;
using PictorialAPI.Repositories;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PictorialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiecesController : ControllerBase
    {
        private readonly IPiecesRepository _piecesRepo;
        public PiecesController(IPiecesRepository pieceRepository)
        {
            _piecesRepo = pieceRepository;
        }
        // GET: api/<PiecesController>
        [HttpGet]
        public List<Pieces> GetAllPieces()
        {
            return _piecesRepo.GetAllPieces();
        }

        // GET api/<PiecesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PiecesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PiecesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PiecesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
