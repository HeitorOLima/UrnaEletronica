using App.Urna.Eletronica.Data;
using App.Urna.Eletronica.Model;
using App.Urna.Eletronica.Repository;
using System.Threading.Tasks;

namespace App.Urna.Eletronica.Business
{
    public class ValidationClass : IValidationClass
    {
        private readonly ICandidateRepository _candidateRepository;

        public ValidationClass(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<bool> ValidarCandidatoExistente(CandidateModel Candidato)
        {
            return await _candidateRepository.BuscarCandidatoPorLegenda(Candidato.LegendaPartido) is null;
        }

        public async Task<bool> ValidarCandidatoPorLegenda(int LegendaPartido)
        {
            return await _candidateRepository.BuscarCandidatoPorLegenda(LegendaPartido) is null;
        }
       
    }
}
