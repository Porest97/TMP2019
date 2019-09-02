using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TMP2019.Models.DataModels.TMPHockeyModels;

namespace TMP2019.Models.DataModels.AccountingModels.DataModels
{
    public class RefFee
    {
        public int Id { get; set; }

        [Display(Name = "Fee Category")]
        public int? FeeCategoryId { get; set; }
        [Display(Name = "Fee Category")]
        [ForeignKey("FeeCategoryId")]
        public FeeCategory FeeCategory { get; set; }

        [Display(Name = "Age & Game Category")]
        public int? GameCategoryId { get; set; }
        [Display(Name = "Age & Game Category")]
        [ForeignKey("GameCategoryId")]
        public GameCategory GameCategory { get; set; }

        [Display(Name = "Fee HD")]
        public double? FeeHD { get; set; }

        [Display(Name = "Fee LD")]
        public double? FeeLD { get; set; }




    }
}
