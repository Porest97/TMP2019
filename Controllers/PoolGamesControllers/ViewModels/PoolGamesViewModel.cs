using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMP2019.Models.DataModels;
using TMP2019.Models.DataModels.TMPHockeyModels;

namespace TMP2019.Controllers.PoolGamesControllers.ViewModels
{
    public class PoolGamesViewModel
    {
        public List<Game> Games { get; internal set; }

        public List<Person> People { get; internal set; }

        public List<Arena> Arenas { get; internal set; }
    }
}
