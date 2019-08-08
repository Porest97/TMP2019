using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TMP2019.Models.DataModels;

namespace TMP2019.Models.DataModels
{
    public class Tournament
    {
        public int Id { get; set; }

        [Display(Name = "Tournament")]
        public string TournamentName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Display(Name = "Description")]
        public string TournamentDescription { get; set; }

        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

       

       

        public ICollection<Team> Teams { get; set; }
        public ICollection<Match> Matches { get; set; }
       

    }
}
