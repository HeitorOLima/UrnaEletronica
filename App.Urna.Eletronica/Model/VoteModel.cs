using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Urna.Eletronica.Model
{
    public class VoteModel
    {
        [Key]
        public int Id { get; set; }
        public int IdCandidato { get; set; }

        public DateTime DtVoto { get; set; }

        [ForeignKey("IdCandidato")]
        public CandidateModel Candidato{ get; set;}


    }
}
