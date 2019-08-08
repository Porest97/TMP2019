using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMP2019.Models.DataModels
{
    public class Match
    {
        public int Id { get; set; }

        
        public int? MatchCategoryId { get; set; }
        [Display(Name = "Category")]
        [ForeignKey("MatchCategoryId")]
        public MatchCategory MatchCategory { get; set; }

        [Display(Name = "Match #")]
        public string MatchNumber { get; set; }

        [Display(Name = "Date&Time")]
        public DateTime MatchDateTime { get; set; }

        
        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

        
        public int? TeamId { get; set; }
        [Display(Name = "Home")]
        [ForeignKey("TeamId")]
        public Team HomeTeam { get; set; }

        
        public int? TeamId1 { get; set; }
        [Display(Name = "Away")]
        [ForeignKey("TeamId1")]
        public Team AwayTeam { get; set; }


        public int? HomeTeamScore { get; set; }

        public int? AwayTeamScore { get; set; }

        [Display(Name = "Score")]
        public string Result { get { return string.Format("{0} {1} {2}", HomeTeamScore, "-", AwayTeamScore); } }

        
        public int? PersonId { get; set; }
        [Display(Name = "HD")]
        [ForeignKey("PersonId")]
        public Person HD1 { get; set; }

        
        public int? PersonId1 { get; set; }
        [Display(Name = "HD")]
        [ForeignKey("PersonId1")]
        public Person HD2 { get; set; }

        
        public int? PersonId2 { get; set; }
        [Display(Name = "LD")]
        [ForeignKey("PersonId2")]
        public Person LD1 { get; set; }

        
        public int? PersonId3 { get; set; }
        [Display(Name = "LD")]
        [ForeignKey("PersonId3")]
        public Person LD2 { get; set; }

        
    }
}
