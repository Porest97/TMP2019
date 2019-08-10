using System.ComponentModel.DataAnnotations;

namespace TMP2019.Models.DataModels.TMPHockeyModels
{
    public class GameStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string GameStatusName { get; set; }
    }
}