using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TMP2019.Models.DataModels.TMPHockeyModels;

namespace TMP2019.Models.DataModels
{
    public class GamesToPoolGame
    {
        public int Id { get; set; }

        public int? PoolGameId { get; set; }
        [Display(Name = "Pool Game")]
        [ForeignKey("PoolGameId")]
        public PoolGame PoolGame { get; set; }

        public int? GameId { get; set; }
        [Display(Name = "Game")]
        [ForeignKey("GameId")]
        public Game Game { get; set; }

    }
}
