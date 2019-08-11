using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMP2019.Data;
using TMP2019.Models.DataModels.TMPHockeyModels.ViewModels;

namespace TMP2019.Controllers.TMPHockeyControllers
{
    public class GameListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ScheduledGames()
        {
            var gamesListViewModel = new GamesListViewModel()
            {
                Games = _context.Game
                       .Include(g => g.Arena)
                       .Include(g => g.AwayTeam)
                       .Include(g => g.GameCategory)
                       .Include(g => g.HD1)
                       .Include(g => g.HD2)
                       .Include(g => g.HomeTeam)
                       .Include(g => g.LD1)
                       .Include(g => g.LD2)
                       .Include(g => g.GameStatus).Where(g => g.Id != 0 && g.GameStatusId == 1).ToList()
            };
            return View(gamesListViewModel);
        }

        public IActionResult StartedGames()
        {
            var gamesListViewModel = new GamesListViewModel()
            {
                Games = _context.Game
                        .Include(g => g.Arena)
                        .Include(g => g.AwayTeam)
                        .Include(g => g.GameCategory)
                        .Include(g => g.HD1)
                        .Include(g => g.HD2)
                        .Include(g => g.HomeTeam)
                        .Include(g => g.LD1)
                        .Include(g => g.LD2)
                        .Include(g => g.GameStatus).Where(g => g.Id != 0 && g.GameStatusId == 2).ToList()
            };
            return View(gamesListViewModel);
        }

        public IActionResult FinalGames()
        {
            var gamesListViewModel = new GamesListViewModel()
            {
                Games = _context.Game
                        .Include(g => g.Arena)
                        .Include(g => g.AwayTeam)
                        .Include(g => g.GameCategory)
                        .Include(g => g.HD1)
                        .Include(g => g.HD2)
                        .Include(g => g.HomeTeam)
                        .Include(g => g.LD1)
                        .Include(g => g.LD2)
                        .Include(g => g.GameStatus).Where(g => g.Id != 0 && g.GameStatusId == 3).ToList()
            };
            return View(gamesListViewModel);
        }

        public IActionResult ArchivedGames()
        {
            
            var gamesListViewModel = new GamesListViewModel()
            {
                Games = _context.Game
                        .Include(g=>g.Arena)
                        .Include(g => g.AwayTeam)
                        .Include(g => g.GameCategory)
                        .Include(g => g.HD1)
                        .Include(g => g.HD2)
                        .Include(g => g.HomeTeam)
                        .Include(g => g.LD1)
                        .Include(g => g.LD2)
                        .Include(g => g.GameStatus).Where(g => g.Id !=0 && g.GameStatusId == 4).ToList()
            };
            return View(gamesListViewModel);
        }
    }
}