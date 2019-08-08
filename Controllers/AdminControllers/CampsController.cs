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
    public class CampsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Camps
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Camp.Include(c => c.Arena);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Camps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camp = await _context.Camp
                .Include(c => c.Arena)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camp == null)
            {
                return NotFound();
            }

            return View(camp);
        }

        // GET: Camps/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            return View();
        }

        // POST: Camps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CampName,StartDate,EndDate,CampDescription,ArenaId")] Camp camp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(camp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", camp.ArenaId);
            return View(camp);
        }

        // GET: Camps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camp = await _context.Camp.FindAsync(id);
            if (camp == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", camp.ArenaId);
            return View(camp);
        }

        // POST: Camps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CampName,StartDate,EndDate,CampDescription,ArenaId")] Camp camp)
        {
            if (id != camp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampExists(camp.Id))
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
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", camp.ArenaId);
            return View(camp);
        }

        // GET: Camps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camp = await _context.Camp
                .Include(c => c.Arena)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camp == null)
            {
                return NotFound();
            }

            return View(camp);
        }

        // POST: Camps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camp = await _context.Camp.FindAsync(id);
            _context.Camp.Remove(camp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampExists(int id)
        {
            return _context.Camp.Any(e => e.Id == id);
        }
    }
}
