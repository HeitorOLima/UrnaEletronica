using App.Urna.Eletronica.Data;
using App.Urna.Eletronica.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Urna.Eletronica.Repository
{
    public interface ICandidateRepository
    {
		Task<CandidateModel> InserirCandidato(CandidateModel Candidato);
        
        Task DeletarCandidato(int IdCandidato);
        
        Task<CandidateModel> BuscarCandidatoPorId(int IdCandidato);
        
        Task<CandidateModel> BuscarCandidatoPorLegenda(int LegendaPartido);
        
        Task<IEnumerable<CandidateModel>> BuscarCandidatos();
    }
}