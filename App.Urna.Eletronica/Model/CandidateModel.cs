using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Urna.Eletronica.Model
{
    public class CandidateModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeViceCandidato { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DtRegistro { get; set; }
        public int LegendaPartido { get; set; }
        public ICollection<VoteModel> Votes { get; set; }

    }
}
