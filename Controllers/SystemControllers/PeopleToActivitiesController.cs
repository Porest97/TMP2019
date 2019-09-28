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
    public class PeopleToActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleToActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PeopleToActivities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PeopleToActivity.Include(p => p.Activity).Include(p => p.Person);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PeopleToActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peopleToActivity = await _context.PeopleToActivity
                .Include(p => p.Activity)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peopleToActivity == null)
            {
                return NotFound();
            }

            return View(peopleToActivity);
        }

        // GET: PeopleToActivities/Create
        public IActionResult Create()
        {
            ViewData["ActivityId"] = new SelectList(_context.Activity, "Id", "ActivityName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: PeopleToActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActivityId,PersonId")] PeopleToActivity peopleToActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peopleToActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityId"] = new SelectList(_context.Activity, "Id", "ActivityName", peopleToActivity.ActivityId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", peopleToActivity.PersonId);
            return View(peopleToActivity);
        }

        // GET: PeopleToActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peopleToActivity = await _context.PeopleToActivity.FindAsync(id);
            if (peopleToActivity == null)
            {
                return NotFound();
            }
            ViewData["ActivityId"] = new SelectList(_context.Activity, "Id", "ActivityName", peopleToActivity.ActivityId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", peopleToActivity.PersonId);
            return View(peopleToActivity);
        }

        // POST: PeopleToActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActivityId,PersonId")] PeopleToActivity peopleToActivity)
        {
            if (id != peopleToActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peopleToActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeopleToActivityExists(peopleToActivity.Id))
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
            ViewData["ActivityId"] = new SelectList(_context.Activity, "Id", "ActivityName", peopleToActivity.ActivityId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", peopleToActivity.PersonId);
            return View(peopleToActivity);
        }

        // GET: PeopleToActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peopleToActivity = await _context.PeopleToActivity
                .Include(p => p.Activity)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peopleToActivity == null)
            {
                return NotFound();
            }

            return View(peopleToActivity);
        }

        // POST: PeopleToActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peopleToActivity = await _context.PeopleToActivity.FindAsync(id);
            _context.PeopleToActivity.Remove(peopleToActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeopleToActivityExists(int id)
        {
            return _context.PeopleToActivity.Any(e => e.Id == id);
        }
    }
}
