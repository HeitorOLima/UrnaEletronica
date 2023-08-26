using App.Urna.Eletronica.Business;
using App.Urna.Eletronica.Model;
using App.Urna.Eletronica.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.Urna.Eletronica.Controllers
{
    [Route("api")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IValidationClass _validationRules;

        public CandidateController(ICandidateRepository candidateRepository, IValidationClass validationRules)
        {
            _candidateRepository = candidateRepository;
            _validationRules = validationRules;
        }

        [HttpPost("candidate")]
        public async Task<IActionResult> RegistrarCandidato([FromBody] CandidateModel Candidato)
        {

            if (Candidato is null)
                return BadRequest("Erro na requisição. O corpo da requisição está vazio");

            if (await _validationRules.ValidarCandidatoExistente(Candidato))
                return BadRequest("Já existe um candidato cadastrado com essa Legenda.");

            try
            {
                Candidato.DtRegistro = DateTime.Now.Date;
                var registedCandidate = await _candidateRepository.InserirCandidato(Candidato);
                return Ok(registedCandidate);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro ao inserir o candidato no banco de dados: {ex.Message}");   
            }
        }

        [HttpDelete("candidate/{IdCandidato}")]
        public async Task<IActionResult> DeletarCandidato(int IdCandidato)
        {
            try
            {
                await _candidateRepository.DeletarCandidato(IdCandidato);
                return NoContent();
            }
            catch
            {
                return NotFound("O candidato que não está sendo removido não foi encontrado no banco."); 
            }
        }

        [HttpGet("candidate/recover/{id}")]
        public async Task<IActionResult> Recuperar(int id)
        {
            var model = await _candidateRepository.BuscarCandidatoPorId(id);
            if (model is null)
                return NotFound(); 
            
            return Ok(model);
        }
    }
}
