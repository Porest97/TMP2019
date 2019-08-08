using System.ComponentModel.DataAnnotations;

namespace TMP2019.Models.DataModels
{
    public class ActivityType
    {
        public int Id { get; set; }

        [Display(Name = "Activity Type")]
        public string ActivityTypeName { get; set; }
    }
}