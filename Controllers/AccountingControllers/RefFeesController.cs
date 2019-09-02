using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMP2019.Data;
using TMP2019.Models.DataModels.AccountingModels.DataModels;

namespace TMP2019.Controllers.AccountingControllers
{
    public class RefFeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefFeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RefFees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RefFee
                .Include(r => r.FeeCategory)
                .Include(r => r.GameCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RefFees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refFee = await _context.RefFee
                .Include(r => r.FeeCategory)
                .Include(r => r.GameCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refFee == null)
            {
                return NotFound();
            }

            return View(refFee);
        }

        // GET: RefFees/Create
        public IActionResult Create()
        {
            ViewData["FeeCategoryId"] = new SelectList(_context.Set<FeeCategory>(), "Id", "FeeCategoryName");
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName");
            return View();
        }

        // POST: RefFees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FeeCategoryId,GameCategoryId,FeeHD,FeeLD")] RefFee refFee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refFee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FeeCategoryId"] = new SelectList(_context.Set<FeeCategory>(), "Id", "FeeCategoryName", refFee.FeeCategoryId);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", refFee.GameCategoryId);
            return View(refFee);
        }

        // GET: RefFees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refFee = await _context.RefFee.FindAsync(id);
            if (refFee == null)
            {
                return NotFound();
            }
            ViewData["FeeCategoryId"] = new SelectList(_context.Set<FeeCategory>(), "Id", "FeeCategoryName", refFee.FeeCategoryId);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", refFee.GameCategoryId);
            return View(refFee);
        }

        // POST: RefFees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FeeCategoryId,GameCategoryId,FeeHD,FeeLD")] RefFee refFee)
        {
            if (id != refFee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refFee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefFeeExists(refFee.Id))
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
            ViewData["FeeCategoryId"] = new SelectList(_context.Set<FeeCategory>(), "Id", "FeeCategoryName", refFee.FeeCategoryId);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "GameCategoryName", refFee.GameCategoryId);
            return View(refFee);
        }

        // GET: RefFees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refFee = await _context.RefFee
                .Include(r => r.FeeCategory)
                .Include(r => r.GameCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refFee == null)
            {
                return NotFound();
            }

            return View(refFee);
        }

        // POST: RefFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refFee = await _context.RefFee.FindAsync(id);
            _context.RefFee.Remove(refFee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefFeeExists(int id)
        {
            return _context.RefFee.Any(e => e.Id == id);
        }
    }
}
