using App.Urna.Eletronica.Data;
using App.Urna.Eletronica.Model;
using App.Urna.Eletronica.Repository;

namespace App.Urna.Eletronica.Business
{
    public class ValidationClass : IValidationClass
    {
        private readonly ICandidateRepository _candidateRepository;

        public ValidationClass(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public bool ValidarCandidatoExistente(CandidateModel Candidato)
        {
            var ResultadoBusca = _candidateRepository.BuscarCandidatoPorLegenda(Candidato.LegendaPartido);

            if (ResultadoBusca == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidarVotoBranco(VoteModel Voto)
        {
            if(Voto == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
