using App.Urna.Eletronica.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Urna.Eletronica.Repository
{
    public interface IVoteRepository
    {
        Task<VoteModel> Votar(VoteModel Voto);
        Task<IEnumerable<CandidateModel>> RecuperarVotosPorCandidato();
    }
}