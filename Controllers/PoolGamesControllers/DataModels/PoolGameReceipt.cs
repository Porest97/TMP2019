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
    public class PoolGameReceipt
    {
        public int Id { get; set; }



        [Display(Name = "Matchledare")]
        public int? PersonId { get; set; }
        [Display(Name = "Matchledare")]
        [ForeignKey("PersonId")]
        public Person HD1 { get; set; }

        // Fee calculations !
        // HD1

        [Display(Name = "FEE")]
        [DataType(DataType.Currency)]
        public int HD1Fee { get; set; } = 0;
        [Display(Name = "Travel")]
        [DataType(DataType.Currency)]
        public int HD1TravelKost { get; set; } = 0;
        [Display(Name = "Alowance")]
        [DataType(DataType.Currency)]
        public int HD1Alowens { get; set; } = 0;
        [Display(Name = "Lategame")]
        [DataType(DataType.Currency)]
        public int HD1LateGameKost { get; set; } = 0;
        [Display(Name = "Other")]
        [DataType(DataType.Currency)]
        public int HD1Other { get; set; } = 0;
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public int HD1TotalFee { get; set; } = 0;

        // DateTime and signing !
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name = "Signature")]
        public string Signature { get; set; }

        // Games to PoolGameReceipt
        [Display(Name ="Games")]
        public List<Game> Games { get; internal set; }

        //Location !
        [Display(Name = "Arena")]
        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

    }
}
