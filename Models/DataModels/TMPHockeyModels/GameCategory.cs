using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TMP2019.Models.DataModels.TMPHockeyModels
{
    public class GameCategory
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        public string GameCategoryName { get; set; }


    }
}
