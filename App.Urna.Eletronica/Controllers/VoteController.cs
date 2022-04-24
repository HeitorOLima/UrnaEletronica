using App.Urna.Eletronica.Model;
using App.Urna.Eletronica.Repository;
using Microsoft.AspNetCore.Mvc;


namespace App.Urna.Eletronica.Controllers
{
    [Route("api")]
    [ApiController]
    public class VoteController : ControllerBase
    {

        private readonly IVoteRepository _voteRepository;

        public VoteController(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository;
        }

        // Post: VotesController/{LegendaPartido}
        [HttpPost("vote")]
        public ActionResult Votar([FromBody] VoteModel Voto)
        {
            _voteRepository.Votar(Voto);
            return Ok();
        }

        // GET VotesController/
        [HttpGet("votes")]
        public ActionResult RecuperarVotosPorCandidato()
        {
            var Candidatos = _voteRepository.RecuperarVotosPorCandidato();
            return Ok(Candidatos);
        }
    }
}
