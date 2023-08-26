using App.Urna.Eletronica.Model;
using System.Threading.Tasks;

namespace App.Urna.Eletronica.Business
{
    public interface IValidationClass
    {
        Task<bool> ValidarCandidatoExistente(CandidateModel Candidato);
        Task<bool> ValidarCandidatoPorLegenda(int LegendaPartido);
    }
}