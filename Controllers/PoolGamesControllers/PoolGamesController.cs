using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMP2019.Controllers.PoolGamesControllers.ViewModels;
using TMP2019.Data;

namespace TMP2019.Controllers.PoolGamesControllers
{
    public class PoolGamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoolGamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ListPoolGames()
        {


            var poolGamesViewModel = new PoolGamesViewModel()
            {


                Games = _context.Game
                       .Include(g => g.Arena)
                       .Include(g => g.AwayTeam)
                       .Include(g => g.GameStatus)
                       .Include(g => g.HD1)
                       .Include(g => g.HD2)
                       .Include(g => g.HomeTeam)
                       .Include(g => g.LD1)
                       .Include(g => g.LD2)
                       .Include(g => g.GameCategory).Where(g => g.Id != 0 && g.GameCategoryId == 20).ToList()
            };
            return View(poolGamesViewModel);
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}