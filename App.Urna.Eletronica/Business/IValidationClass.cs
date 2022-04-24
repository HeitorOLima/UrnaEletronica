using App.Urna.Eletronica.Model;

namespace App.Urna.Eletronica.Business
{
    public interface IValidationClass
    {
        bool ValidarCandidatoExistente(CandidateModel Candidato);
    }
}