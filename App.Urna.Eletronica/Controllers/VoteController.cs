using App.Urna.Eletronica.Business;
using App.Urna.Eletronica.Model;
using App.Urna.Eletronica.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace App.Urna.Eletronica.Controllers
{
    [Route("api")]
    [ApiController]
    public class VoteController : ControllerBase
    {

        private readonly IVoteRepository _voteRepository;
        private readonly IValidationClass _validations;

        public VoteController(IVoteRepository voteRepository, IValidationClass validations)
        {
            _voteRepository = voteRepository;
            _validations = validations;
        }

        [HttpPost("vote")]
        public async Task<IActionResult> Votar([FromBody] VoteModel Voto)
        {
            if(Voto is null)
                return Ok("O voto foi computado com sucesso!");

            try
            {
                if (await _validations.ValidarCandidatoPorLegenda(Voto.IdCandidato))
                    await _voteRepository.Votar(Voto);
            
                return Ok("O voto foi computado com sucesso!");
                            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao computar voto: {ex.Message}");
            }
        }

        [HttpGet("votes")]
        public ActionResult RecuperarVotosPorCandidato()
        {
            try
            {
                var Candidatos = _voteRepository.RecuperarVotosPorCandidato();
             
                return Ok(Candidatos);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao recuperar votos: {ex.Message}");
            }
        }
    }
}
