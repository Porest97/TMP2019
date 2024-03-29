﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMP2019.Models.DataModels
{
    public class Receipt
    {
        [Display(Name = "#")]
        public int Id { get; set; }

        [Display(Name = "Match")]
        public int? MatchId { get; set; }
        [Display(Name = "Match")]
        [ForeignKey("MatchId")]
        public Match Match { get; set; }

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
        [DataType(DataType.Currency)]
        public int HD1Fee { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int HD1TravelKost { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int HD1Alowens { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int HD1LateGameKost { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int HD1TotalFee { get; set; } = 0;

        [DataType(DataType.Currency)]
        public int HD2Fee { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int HD2TravelKost { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int HD2Alowens { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int HD2LateGameKost { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int HD2TotalFee { get; set; } = 0;

        [DataType(DataType.Currency)]
        public int LD1Fee { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int LD1TravelKost { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int LD1Alowens { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int LD1LateGameKost { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int LD1TotalFee { get; set; } = 0;

        [DataType(DataType.Currency)]
        public int LD2Fee { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int LD2TravelKost { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int LD2Alowens { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int LD2LateGameKost { get; set; } = 0;
        [DataType(DataType.Currency)]
        public int LD2TotalFee { get; set; } = 0;

        [DataType(DataType.Currency)]
        public int GameTotalKost { get; set; } = 0;
    }
}
