using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMP2019.Data;
using TMP2019.Models.DataModels;

namespace TMP2019.Controllers.AdminControllers
{
    public class MatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Match.Include(m => m.Arena).Include(m => m.AwayTeam).Include(m => m.HD1).Include(m => m.HD2).Include(m => m.HomeTeam).Include(m => m.LD1).Include(m => m.LD2).Include(m => m.MatchCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.Arena)
                .Include(m => m.AwayTeam)
                .Include(m => m.HD1)
                .Include(m => m.HD2)
                .Include(m => m.HomeTeam)
                .Include(m => m.LD1)
                .Include(m => m.LD2)
                .Include(m => m.MatchCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Set<Arena>(), "Id", "Id");
            ViewData["TeamId1"] = new SelectList(_context.Set<Team>(), "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["TeamId"] = new SelectList(_context.Set<Team>(), "Id", "Id");
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["MatchCategoryId"] = new SelectList(_context.Set<MatchCategory>(), "Id", "Id");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatchCategoryId,MatchNumber,MatchDateTime,ArenaId,TeamId,TeamId1,HomeTeamScore,AwayTeamScore,PersonId,PersonId1,PersonId2,PersonId3")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArenaId"] = new SelectList(_context.Set<Arena>(), "Id", "Id", match.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Set<Team>(), "Id", "Id", match.TeamId1);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", match.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", match.PersonId1);
            ViewData["TeamId"] = new SelectList(_context.Set<Team>(), "Id", "Id", match.TeamId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id", match.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "Id", match.PersonId3);
            ViewData["MatchCategoryId"] = new SelectList(_context.Set<MatchCategory>(), "Id", "Id", match.MatchCategoryId);
            return View(match);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Set<Arena>(), "Id", "Id", match.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Set<Team>(), "Id", "Id", match.TeamId1);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", match.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", match.PersonId1);
            ViewData["TeamId"] = new SelectList(_context.Set<Team>(), "Id", "Id", match.TeamId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id", match.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "Id", match.PersonId3);
            ViewData["MatchCategoryId"] = new SelectList(_context.Set<MatchCategory>(), "Id", "Id", match.MatchCategoryId);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatchCategoryId,MatchNumber,MatchDateTime,ArenaId,TeamId,TeamId1,HomeTeamScore,AwayTeamScore,PersonId,PersonId1,PersonId2,PersonId3")] Match match)
        {
            if (id != match.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
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
            ViewData["ArenaId"] = new SelectList(_context.Set<Arena>(), "Id", "Id", match.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Set<Team>(), "Id", "Id", match.TeamId1);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", match.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", match.PersonId1);
            ViewData["TeamId"] = new SelectList(_context.Set<Team>(), "Id", "Id", match.TeamId);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id", match.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "Id", match.PersonId3);
            ViewData["MatchCategoryId"] = new SelectList(_context.Set<MatchCategory>(), "Id", "Id", match.MatchCategoryId);
            return View(match);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.Arena)
                .Include(m => m.AwayTeam)
                .Include(m => m.HD1)
                .Include(m => m.HD2)
                .Include(m => m.HomeTeam)
                .Include(m => m.LD1)
                .Include(m => m.LD2)
                .Include(m => m.MatchCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var match = await _context.Match.FindAsync(id);
            _context.Match.Remove(match);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
            return _context.Match.Any(e => e.Id == id);
        }
    }
}
