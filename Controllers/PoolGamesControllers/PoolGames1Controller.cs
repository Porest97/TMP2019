using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMP2019.Controllers.PoolGamesControllers.DataModels;
using TMP2019.Data;

namespace TMP2019.Controllers.PoolGamesControllers
{
    public class PoolGames1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoolGames1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PoolGames1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PoolGame
                .Include(p => p.Arena)
                .Include(p => p.Game1)
                .Include(p => p.Game2)
                .Include(p => p.GameCategory)
                .Include(p => p.HD1)
                .Include(p => p.HD2)
                .Include(p => p.Team);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PoolGames1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poolGame = await _context.PoolGame
                .Include(p => p.Arena)
                .Include(p => p.Game1)
                .Include(p => p.Game2)
                .Include(p => p.GameCategory)
                .Include(p => p.HD1)
                .Include(p => p.HD2)
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poolGame == null)
            {
                return NotFound();
            }

            return View(poolGame);
        }

        // GET: PoolGames1/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Teams");
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "Teams");
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName");
            return View();
        }

        // POST: PoolGames1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PoolGameDateTime,GameCategoryId,TeamId,ArenaId,GameId,GameId1,PersonId,PersonId1")] PoolGame poolGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poolGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", poolGame.ArenaId);
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Teams", poolGame.GameId);
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "Teams", poolGame.GameId1);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", poolGame.GameCategoryId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", poolGame.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", poolGame.PersonId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", poolGame.TeamId);
            return View(poolGame);
        }

        // GET: PoolGames1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poolGame = await _context.PoolGame.FindAsync(id);
            if (poolGame == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", poolGame.ArenaId);
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Teams", poolGame.GameId);
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "Teams", poolGame.GameId1);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", poolGame.GameCategoryId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", poolGame.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", poolGame.PersonId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", poolGame.TeamId);
            return View(poolGame);
        }

        // POST: PoolGames1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PoolGameDateTime,GameCategoryId,TeamId,ArenaId,GameId,GameId1,PersonId,PersonId1")] PoolGame poolGame)
        {
            if (id != poolGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poolGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoolGameExists(poolGame.Id))
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
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", poolGame.ArenaId);
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Teams", poolGame.GameId);
            ViewData["GameId1"] = new SelectList(_context.Game, "Id", "Teams", poolGame.GameId1);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", poolGame.GameCategoryId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", poolGame.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", poolGame.PersonId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", poolGame.TeamId);
            return View(poolGame);
        }

        // GET: PoolGames1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poolGame = await _context.PoolGame
                .Include(p => p.Arena)
                .Include(p => p.Game1)
                .Include(p => p.Game2)
                .Include(p => p.GameCategory)
                .Include(p => p.HD1)
                .Include(p => p.HD2)
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poolGame == null)
            {
                return NotFound();
            }

            return View(poolGame);
        }

        // POST: PoolGames1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poolGame = await _context.PoolGame.FindAsync(id);
            _context.PoolGame.Remove(poolGame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoolGameExists(int id)
        {
            return _context.PoolGame.Any(e => e.Id == id);
        }
    }
}
