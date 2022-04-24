using App.Urna.Eletronica.Data;
using App.Urna.Eletronica.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace App.Urna.Eletronica.Repository
{
    public class VoteRepository : IVoteRepository
    {
        private readonly UrnaEletronicaDbContext _DbContext;

        public VoteRepository(UrnaEletronicaDbContext DbContext)
        {
            _DbContext = DbContext;
        }


        public void Votar(VoteModel Voto)
        {
            _DbContext.Votos.Add(Voto);
            _DbContext.SaveChanges();
        }

        public IEnumerable<CandidateModel> RecuperarVotosPorCandidato()
        {
            return _DbContext.Candidatos.Include(x => x.Votes).ToList();

        }
    }
}
