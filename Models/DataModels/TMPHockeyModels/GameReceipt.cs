using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMP2019.Models.DataModels.TMPHockeyModels
{
    public class GameReceipt
    {
        public int Id { get; set; }

        [Display(Name = "Game")]
        public int? GameId { get; set; }
        [Display(Name = "Game")]
        [ForeignKey("GameId")]
        public Game Game { get; set; }

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

        // Fee calculations !
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
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public int HD1TotalFee { get; set; } = 0;

        [Display(Name = "FEE")]
        [DataType(DataType.Currency)]
        public int HD2Fee { get; set; } = 0;
        [Display(Name = "Travel")]
        [DataType(DataType.Currency)]
        public int HD2TravelKost { get; set; } = 0;
        [Display(Name = "Alowance")]
        [DataType(DataType.Currency)]
        public int HD2Alowens { get; set; } = 0;
        [Display(Name = "Lategame")]
        [DataType(DataType.Currency)]
        public int HD2LateGameKost { get; set; } = 0;
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public int HD2TotalFee { get; set; } = 0;

        [Display(Name = "FEE")]
        [DataType(DataType.Currency)]
        public int LD1Fee { get; set; } = 0;
        [Display(Name = "Travel")]
        [DataType(DataType.Currency)]
        public int LD1TravelKost { get; set; } = 0;
        [Display(Name = "Alowance")]
        [DataType(DataType.Currency)]
        public int LD1Alowens { get; set; } = 0;
        [Display(Name = "Lategame")]
        [DataType(DataType.Currency)]
        public int LD1LateGameKost { get; set; } = 0;
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public int LD1TotalFee { get; set; } = 0;


        [Display(Name = "FEE")]
        [DataType(DataType.Currency)]
        public int LD2Fee { get; set; } = 0;
        [Display(Name = "Travel")]
        [DataType(DataType.Currency)]
        public int LD2TravelKost { get; set; } = 0;
        [Display(Name = "Alowens")]
        [DataType(DataType.Currency)]
        public int LD2Alowens { get; set; } = 0;
        [Display(Name = "Lategame")]
        [DataType(DataType.Currency)]
        public int LD2LateGameKost { get; set; } = 0;
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public int LD2TotalFee { get; set; } = 0;

        [Display(Name = "Game Total")]
        [DataType(DataType.Currency)]
        public int GameTotalKost { get; set; } = 0;


    }
}
