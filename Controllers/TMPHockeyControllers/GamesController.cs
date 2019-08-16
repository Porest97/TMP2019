using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMP2019.Data;
using TMP2019.Models.DataModels.TMPHockeyModels;

namespace TMP2019.Controllers.TMPHockeyControllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder , string searchString , string searchString1)
        {
            ViewData["ArenaSortParm"] = sortOrder == "Arena" ? "arena_desc" : "Arena";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["StatusSortParm"] = sortOrder == "Status" ? "status_desc" : "Status";
            ViewData["GameCategorySortParm"] = sortOrder == "GameCategory" ? "gameCategory_desc" : "GameCategory";
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentFilter1"] = searchString1;
            var games = from g in _context.Game
                        .Include(g => g.Arena)
                        .Include(g => g.AwayTeam)
                        .Include(g => g.GameCategory)
                        .Include(g => g.HD1)
                        .Include(g => g.HD2)
                        .Include(g => g.HomeTeam)
                        .Include(g => g.LD1)
                        .Include(g => g.LD2)
                        .Include(g => g.GameStatus)
                        select g;
            if (!String.IsNullOrEmpty(searchString))
            {
                games = games.Where(g => g.Arena.ArenaName.Contains(searchString) 
                
                
                
                );
            }
            // SS for GameStatus
            if (!String.IsNullOrEmpty(searchString1))
            {
                games = games.Where(g => g.GameStatus.GameStatusName.Contains(searchString1)                          


                );
            }
            switch (sortOrder)
            {
                case "arena_desc":
                    games = games.OrderByDescending(g => g.Arena.ArenaName).Where(g => g.Id != 0 && g.GameStatusId == 1);
                    break;
                case "Arena":
                    games = games.OrderBy(g => g.Arena.ArenaName).Where(g => g.Id != 0 && g.GameStatusId == 1);
                    break;                
                case "Date":
                    games = games.OrderBy(g => g.GameDateTime).Where(g => g.Id != 0 && g.GameStatusId == 1);
                    break;
                case "date_desc":
                    games = games.OrderByDescending(g => g.GameDateTime).Where(g => g.Id != 0 && g.GameStatusId == 1);
                    break;
                case "status_desc":
                    games = games.OrderByDescending(g => g.GameStatus.GameStatusName);
                    break;
                case "Status":
                    games = games.OrderBy(g => g.GameStatus.GameStatusName);
                    break;
                case "gameCategory_desc":
                    games = games.OrderByDescending(g => g.GameCategory.GameCategoryName).Where(g => g.Id != 0 && g.GameStatusId == 1);
                    break;
                case "GameCategory":
                    games = games.OrderBy(g => g.GameCategory.GameCategoryName).Where(g => g.Id != 0 && g.GameStatusId == 1);
                    break;
                default:
                    games = games.OrderBy(g => g.GameDateTime).Where(g=> g.Id !=0 && g.GameStatusId == 1);
                    break;
            }
            return View(await games.AsNoTracking().ToListAsync());
        }

        //// GET: Games
        //public async Task<IActionResult> Index(string sortOrder)
        //{

        //    var applicationDbContext = _context.Game
        //        .Include(g => g.Arena)
        //        .Include(g => g.AwayTeam)
        //        .Include(g => g.GameCategory)
        //        .Include(g => g.HD1)
        //        .Include(g => g.HD2)
        //        .Include(g => g.HomeTeam)
        //        .Include(g => g.LD1)
        //        .Include(g => g.LD2)
        //        .Include(g=> g.GameStatus);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Arena)
                .Include(g => g.AwayTeam)
                .Include(g => g.GameCategory)
                .Include(g => g.HD1)
                .Include(g => g.HD2)
                .Include(g => g.HomeTeam)
                .Include(g => g.LD1)
                .Include(g => g.LD2)
                .Include(g => g.GameStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName");
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName");
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "GameStatusName");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameCategoryId,GameNumber,GameDateTime,ArenaId,TeamId,TeamId1,HomeTeamScore,AwayTeamScore,PersonId,PersonId1,PersonId2,PersonId3,TSMNumber,GameStatusId")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", game.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName", game.TeamId1);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", game.GameCategoryId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", game.TeamId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId3);
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "GameStatusName", game.GameStatusId);
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", game.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName", game.TeamId1);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", game.GameCategoryId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", game.TeamId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId3);
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "GameStatusName", game.GameStatusId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameCategoryId,GameNumber,GameDateTime,ArenaId,TeamId,TeamId1,HomeTeamScore,AwayTeamScore,PersonId,PersonId1,PersonId2,PersonId3,TSMNumber,GameStatusId")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", game.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName", game.TeamId1);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", game.GameCategoryId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", game.TeamId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId3);
            ViewData["GameStatusId"] = new SelectList(_context.GameStatus, "Id", "GameStatusName", game.GameStatusId);
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Arena)
                .Include(g => g.AwayTeam)
                .Include(g => g.GameCategory)
                .Include(g => g.HD1)
                .Include(g => g.HD2)
                .Include(g => g.HomeTeam)
                .Include(g => g.LD1)
                .Include(g => g.LD2)
                .Include(g => g.GameStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.FindAsync(id);
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}
