using App.Urna.Eletronica.Data;
using App.Urna.Eletronica.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Urna.Eletronica.Repository
{
	public class VoteRepository : IVoteRepository
    {
        private readonly UrnaEletronicaDbContext _DbContext;

        public VoteRepository(UrnaEletronicaDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<VoteModel> Votar(VoteModel Voto)
        {
            await _DbContext.Votos.AddAsync(Voto);
            await _DbContext.SaveChangesAsync();

            return Voto;
        }

        public async Task<IEnumerable<CandidateModel>> RecuperarVotosPorCandidato()
        {
            return await _DbContext.Candidatos.Include(x => x.Votes).OrderByDescending(x=> x.Votes.Count).ToListAsync();
        }
    }
}
