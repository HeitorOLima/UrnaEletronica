using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Urna.Eletronica.Model
{
	public class VoteModel
    {
        [Key]
        public int Id { get; set; }

        [Range(10, 101, ErrorMessage = "Id do candidato deve ter 2 dígitos.")]
        public int IdCandidato { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DtVoto { get; set; }

        [ForeignKey("IdCandidato")]
        public CandidateModel Candidato{ get; set;}


    }
}
