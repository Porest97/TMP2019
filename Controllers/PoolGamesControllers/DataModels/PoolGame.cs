using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TMP2019.Models.DataModels;
using TMP2019.Models.DataModels.TMPHockeyModels;

namespace TMP2019.Controllers.PoolGamesControllers.DataModels
{
    public class PoolGame
    {
        public int Id { get; set; }

        [Display(Name = "Date&Time")]
        public DateTime PoolGameDateTime { get; set; }

        [Display(Name = "Category")]
        public int? GameCategoryId { get; set; }
        [Display(Name = "Category")]
        [ForeignKey("GameCategoryId")]
        public GameCategory GameCategory { get; set; }

        [Display(Name = "Host")]
        public int? TeamId { get; set; }
        [Display(Name = "Host")]
        [ForeignKey("TeamId")]
        public Team Team { get; set; }

        [Display(Name = "Arena")]
        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

        //Games added to the PoolGame !

        [Display(Name = "Game 1")]
        public int? GameId { get; set; }
        [Display(Name = "Game 1")]
        [ForeignKey("GameId")]
        public Game Game1 { get; set; }

        [Display(Name = "Game 2")]
        public int? GameId1 { get; set; }
        [Display(Name = "Game 2")]
        [ForeignKey("GameId1")]
        public Game Game2 { get; set; }

        // Referees added to the gamezones !

        [Display(Name = "HDZ1")]
        public int? PersonId { get; set; }
        [Display(Name = "HDZ1")]
        [ForeignKey("PersonId")]
        public Person HD1 { get; set; }

        [Display(Name = "HDZ2")]
        public int? PersonId1 { get; set; }
        [Display(Name = "HDZ2")]
        [ForeignKey("PersonId1")]
        public Person HD2 { get; set; }


    }
}
