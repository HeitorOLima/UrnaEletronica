using App.Urna.Eletronica.Data;
using App.Urna.Eletronica.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Urna.Eletronica.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly UrnaEletronicaDbContext _dbContext;

        public CandidateRepository(UrnaEletronicaDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<CandidateModel> InserirCandidato(CandidateModel Candidato)
        {
            await _dbContext.Candidatos.AddAsync(Candidato);
            await _dbContext.SaveChangesAsync();

            return Candidato;
        }
        
        public async Task DeletarCandidato(int Id)
        {
            var Candidato = await _dbContext.Candidatos.FindAsync(Id);
         
            _dbContext.Candidatos.Remove(Candidato);
            _dbContext.SaveChanges();
        }
        
        public async Task<CandidateModel> BuscarCandidatoPorId(int Id)
        {
            return await _dbContext.Candidatos.FindAsync(Id);
        }
        
        public async Task<CandidateModel> BuscarCandidatoPorLegenda(int LegendaPartido)
        {
            return await _dbContext.Candidatos.Where(x=> x.LegendaPartido == LegendaPartido).FirstOrDefaultAsync();
            
        }
        
        public async Task<IEnumerable<CandidateModel>> BuscarCandidatos()
        {
            return await _dbContext.Candidatos.ToListAsync();
        } 
    }
}
