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
    public class ReceiptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceiptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Receipts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Receipt.Include(r => r.HD1).Include(r => r.HD2).Include(r => r.LD1).Include(r => r.LD2).Include(r => r.Match);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Receipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt
                .Include(r => r.HD1)
                .Include(r => r.HD2)
                .Include(r => r.LD1)
                .Include(r => r.LD2)
                .Include(r => r.Match)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // GET: Receipts/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["MatchId"] = new SelectList(_context.Match, "Id", "Id");
            return View();
        }

        // POST: Receipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatchId,PersonId,PersonId1,PersonId2,PersonId3,HD1Fee,HD1TravelKost,HD1Alowens,HD1LateGameKost,HD1TotalFee,HD2Fee,HD2TravelKost,HD2Alowens,HD2LateGameKost,HD2TotalFee,LD1Fee,LD1TravelKost,LD1Alowens,LD1LateGameKost,LD1TotalFee,LD2Fee,LD2TravelKost,LD2Alowens,LD2LateGameKost,LD2TotalFee,GameTotalKost")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", receipt.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", receipt.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id", receipt.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "Id", receipt.PersonId3);
            ViewData["MatchId"] = new SelectList(_context.Match, "Id", "Id", receipt.MatchId);
            return View(receipt);
        }

        // GET: Receipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", receipt.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", receipt.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id", receipt.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "Id", receipt.PersonId3);
            ViewData["MatchId"] = new SelectList(_context.Match, "Id", "Id", receipt.MatchId);
            return View(receipt);
        }

        // POST: Receipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatchId,PersonId,PersonId1,PersonId2,PersonId3,HD1Fee,HD1TravelKost,HD1Alowens,HD1LateGameKost,HD1TotalFee,HD2Fee,HD2TravelKost,HD2Alowens,HD2LateGameKost,HD2TotalFee,LD1Fee,LD1TravelKost,LD1Alowens,LD1LateGameKost,LD1TotalFee,LD2Fee,LD2TravelKost,LD2Alowens,LD2LateGameKost,LD2TotalFee,GameTotalKost")] Receipt receipt)
        {
            if (id != receipt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptExists(receipt.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", receipt.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", receipt.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "Id", receipt.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "Id", receipt.PersonId3);
            ViewData["MatchId"] = new SelectList(_context.Match, "Id", "Id", receipt.MatchId);
            return View(receipt);
        }

        // GET: Receipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt
                .Include(r => r.HD1)
                .Include(r => r.HD2)
                .Include(r => r.LD1)
                .Include(r => r.LD2)
                .Include(r => r.Match)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receipt = await _context.Receipt.FindAsync(id);
            _context.Receipt.Remove(receipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptExists(int id)
        {
            return _context.Receipt.Any(e => e.Id == id);
        }
    }
}
