using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMP2019.Controllers.PoolGamesControllers.DataModels;
using TMP2019.Controllers.PoolGamesControllers.ViewModels;
using TMP2019.Data;

namespace TMP2019.Controllers.PoolGamesControllers
{
    public class PoolGameReceiptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoolGameReceiptsController(ApplicationDbContext context)
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

        // GET: PoolGameReceipts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PoolGameReceipt
                .Include(p => p.HD1)
                .Include(p => p.Arena);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PoolGameReceipts HttpPost !
        [HttpPost]
        public  IActionResult Index(PoolGameReceipt poolGameReceipt)
        {
            var applicationDbContext = _context.PoolGameReceipt
                .Include(p => p.HD1)
                .Include(p => p.Arena);
            poolGameReceipt.HD1TotalFee = poolGameReceipt.HD1Fee + poolGameReceipt.HD1Alowens + poolGameReceipt.HD1TravelKost + poolGameReceipt.HD1LateGameKost + poolGameReceipt.HD1Other;
            return View(poolGameReceipt);
        }

        // GET: PoolGameReceipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poolGameReceipt = await _context.PoolGameReceipt
                .Include(p => p.HD1)
                .Include(p => p.Arena)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poolGameReceipt == null)
            {
                return NotFound();
            }

            return View(poolGameReceipt);
        }

        // GET: PoolGameReceipts/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            return View();
        }

        // POST: PoolGameReceipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,HD1Fee,HD1TravelKost,HD1Alowens,HD1LateGameKost,HD1Other,HD1TotalFee,Date,Signature,ArenaId")] PoolGameReceipt poolGameReceipt)
        {
            if (ModelState.IsValid)
            {
                var applicationDbContext = _context.PoolGameReceipt
                .Include(p => p.HD1)
                .Include(p => p.Arena);
                poolGameReceipt.HD1TotalFee = poolGameReceipt.HD1Fee + poolGameReceipt.HD1Alowens + poolGameReceipt.HD1TravelKost + poolGameReceipt.HD1LateGameKost + poolGameReceipt.HD1Other;

                _context.Add(poolGameReceipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", poolGameReceipt.PersonId);
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", poolGameReceipt.ArenaId);
            return View(poolGameReceipt);
        }

        // GET: PoolGameReceipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poolGameReceipt = await _context.PoolGameReceipt.FindAsync(id);
            if (poolGameReceipt == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", poolGameReceipt.PersonId);
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", poolGameReceipt.ArenaId);
            return View(poolGameReceipt);
        }

        // POST: PoolGameReceipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,HD1Fee,HD1TravelKost,HD1Alowens,HD1LateGameKost,HD1Other,HD1TotalFee,Date,Signature,ArenaId")] PoolGameReceipt poolGameReceipt)
        {
            if (id != poolGameReceipt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var applicationDbContext = _context.PoolGameReceipt
                    .Include(p => p.HD1)
                    .Include(p => p.Arena);
                    poolGameReceipt.HD1TotalFee = poolGameReceipt.HD1Fee + poolGameReceipt.HD1Alowens + poolGameReceipt.HD1TravelKost + poolGameReceipt.HD1LateGameKost + poolGameReceipt.HD1Other;

                    _context.Update(poolGameReceipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoolGameReceiptExists(poolGameReceipt.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", poolGameReceipt.PersonId);
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", poolGameReceipt.ArenaId);
            return View(poolGameReceipt);
        }

        // GET: PoolGameReceipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poolGameReceipt = await _context.PoolGameReceipt
                .Include(p => p.HD1)
                .Include(p => p.Arena)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poolGameReceipt == null)
            {
                return NotFound();
            }

            return View(poolGameReceipt);
        }

        // POST: PoolGameReceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poolGameReceipt = await _context.PoolGameReceipt.FindAsync(id);
            _context.PoolGameReceipt.Remove(poolGameReceipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoolGameReceiptExists(int id)
        {
            return _context.PoolGameReceipt.Any(e => e.Id == id);
        }
    }
}
