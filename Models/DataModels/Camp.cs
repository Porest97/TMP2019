using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMP2019.Models.DataModels
{
    public class Camp
    {
        public int Id { get; set; }

        [Display(Name = "Camp")]
        public string CampName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Display(Name = "Description")]
        public string CampDescription { get; set; }

        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

        public ICollection<Person> People { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}
