using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMP2019.Models.DataModels.TMPHockeyModels
{
    public class Game
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        public int? GameCategoryId { get; set; }
        [Display(Name = "Category")]
        [ForeignKey("GameCategoryId")]
        public GameCategory GameCategory { get; set; }

        [Display(Name = "Game #")]
        public string GameNumber { get; set; }

        [Display(Name = "Date&Time")]
        public DateTime GameDateTime { get; set; }

        [Display(Name = "Arena")]
        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

        [Display(Name = "Home")]
        public int? TeamId { get; set; }
        [Display(Name = "Home")]
        [ForeignKey("TeamId")]
        public Team HomeTeam { get; set; }

        [Display(Name = "Away")]
        public int? TeamId1 { get; set; }
        [Display(Name = "Away")]
        [ForeignKey("TeamId1")]
        public Team AwayTeam { get; set; }

        [Display(Name = "Score Home Team")]
        public int? HomeTeamScore { get; set; }

        [Display(Name = "Score Away Team")]
        public int? AwayTeamScore { get; set; }

        [Display(Name = "Score")]
        public string Result { get { return string.Format("{0} {1} {2}", HomeTeamScore, "-", AwayTeamScore); } }

        [Display(Name = "HD")]
        public int? PersonId { get; set; }
        [Display(Name = "HD")]
        [ForeignKey("PersonId")]
        public Person HD1 { get; set; }

        [Display(Name = "HD")]
        public int? PersonId1 { get; set; }
        [Display(Name = "HD")]
        [ForeignKey("PersonId1")]
        public Person HD2 { get; set; }

        [Display(Name = "LD")]
        public int? PersonId2 { get; set; }
        [Display(Name = "LD")]
        [ForeignKey("PersonId2")]
        public Person LD1 { get; set; }

        [Display(Name = "LD")]
        public int? PersonId3 { get; set; }
        [Display(Name = "LD")]
        [ForeignKey("PersonId3")]
        public Person LD2 { get; set; }

        [Display(Name = "TSM #")]
        public string TSMNumber { get; set; }

        [Display(Name = "Status")]
        public int? GameStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("GameStatusId")]
        public GameStatus GameStatus { get; set; }



    }
}
