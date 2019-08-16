using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMP2019.Models.DataModels.TMPHockeyModels.ViewModels
{
    public class GameReceiptViewModel
    {
        
        public int? GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        [Display(Name = "GameString")]
        public string GameString { get { return string.Format("{0} {1} {2} {3}", Game.GameDateTime, Game.HomeTeam.TeamName.ToString(),"-",Game.AwayTeam.TeamName.ToString()); } }




    }
}
