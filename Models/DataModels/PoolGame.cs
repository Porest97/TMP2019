using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMP2019.Models.DataModels
{
    public class PoolGame
    {
        public int Id { get; set; }

        [Display(Name = "Pool Game")]
        public string PoolGameName { get; set; }

        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

        // = First Games GameDateTime
        [Display(Name = "Date & Time")]
        public DateTime StartDateTime { get; set; }


    }
}