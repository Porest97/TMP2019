using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMP2019.Models.DataModels.TSMModels
{
    public class TSMGame
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        public int? TSMGameCategoryId { get; set; }
        [Display(Name = "Category")]
        [ForeignKey("TSMGameCategoryId")]
        public TSMGameCategory TSMGameCategory { get; set; }
    }
}
