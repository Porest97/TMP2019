using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TMP2019.Models.DataModels;
using TMP2019.Models.DataModels.TMPHockeyModels;

namespace TMP2019.Models.ViewModels
{
    public class ActivityViewModel
    {
        [Display(Name = "Activity")]
        public string ActivityName { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        [Display(Name = "Description")]
        public string ActivityDescription { get; set; }

        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

        public int? ActivityTypeId { get; set; }
        [Display(Name = "Activity Type")]
        [ForeignKey("ActivityTypeId")]
        public ActivityType ActivityType { get; set; }

        public ICollection<Person> People { get; set; }


        public ICollection<Game> Games { get; set; }
    }
}
