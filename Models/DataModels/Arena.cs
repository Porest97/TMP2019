using System.ComponentModel.DataAnnotations;

namespace TMP2019.Models.DataModels
{
    public class Arena
    {
        public int Id { get; set; }

        [Display(Name = "Arena")]
        public string ArenaName { get; set; }
    }
}