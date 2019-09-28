using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMP2019.Data;
using TMP2019.Models.DataModels;

namespace TMP2019.Controllers.SystemControllers
{
    public class GamesToActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesToActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GamesToActivities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GamesToActivity.Include(g => g.Activity).Include(g => g.Game);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GamesToActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamesToActivity = await _context.GamesToActivity
                .Include(g => g.Activity)
                .Include(g => g.Game)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamesToActivity == null)
            {
                return NotFound();
            }

            return View(gamesToActivity);
        }

        // GET: GamesToActivities/Create
        public IActionResult Create()
        {
            ViewData["ActivityId"] = new SelectList(_context.Activity, "Id", "ActivityName");
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber");
            return View();
        }

        // POST: GamesToActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActivityId,GameId")] GamesToActivity gamesToActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamesToActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityId"] = new SelectList(_context.Activity, "Id", "ActivityName", gamesToActivity.ActivityId);
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", gamesToActivity.GameId);
            return View(gamesToActivity);
        }

        // GET: GamesToActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamesToActivity = await _context.GamesToActivity.FindAsync(id);
            if (gamesToActivity == null)
            {
                return NotFound();
            }
            ViewData["ActivityId"] = new SelectList(_context.Activity, "Id", "ActivityName", gamesToActivity.ActivityId);
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", gamesToActivity.GameId);
            return View(gamesToActivity);
        }

        // POST: GamesToActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActivityId,GameId")] GamesToActivity gamesToActivity)
        {
            if (id != gamesToActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamesToActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamesToActivityExists(gamesToActivity.Id))
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
            ViewData["ActivityId"] = new SelectList(_context.Activity, "Id", "ActivityName", gamesToActivity.ActivityId);
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", gamesToActivity.GameId);
            return View(gamesToActivity);
        }

        // GET: GamesToActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamesToActivity = await _context.GamesToActivity
                .Include(g => g.Activity)
                .Include(g => g.Game)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamesToActivity == null)
            {
                return NotFound();
            }

            return View(gamesToActivity);
        }

        // POST: GamesToActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gamesToActivity = await _context.GamesToActivity.FindAsync(id);
            _context.GamesToActivity.Remove(gamesToActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamesToActivityExists(int id)
        {
            return _context.GamesToActivity.Any(e => e.Id == id);
        }
    }
}
