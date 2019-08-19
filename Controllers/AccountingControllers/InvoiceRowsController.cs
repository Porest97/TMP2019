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
    public class InvoiceRowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InvoiceRows
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InvoiceRow
                .Include(i => i.Article);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WorkReports HttpPost !
        [HttpPost]
        public IActionResult Index(InvoiceRow invoiceRow)
        {
            var applicationDbContext = _context.InvoiceRow
                .Include(i => i.Article);
            invoiceRow.RowTotal = invoiceRow.Quantity * invoiceRow.ArticlePrice;    
            return View(invoiceRow);
        }


        // GET: InvoiceRows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceRow = await _context.InvoiceRow
                .Include(i => i.Article)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceRow == null)
            {
                return NotFound();
            }

            return View(invoiceRow);
        }

        // GET: InvoiceRows/Create
        public IActionResult Create()
        {
            ViewData["ArticleId"] = new SelectList(_context.Article, "Id", "Id");
            return View();
        }

        // POST: InvoiceRows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArticleId,Quantity,ArticlePrice,RowTotal")] InvoiceRow invoiceRow)
        {
            if (ModelState.IsValid)
            {
                var applicationDbContext = _context.InvoiceRow
                .Include(i => i.Article);
                invoiceRow.RowTotal = invoiceRow.Quantity * invoiceRow.ArticlePrice;

                _context.Add(invoiceRow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticleId"] = new SelectList(_context.Article, "Id", "Id", invoiceRow.ArticleId);
            return View(invoiceRow);
        }

        // GET: InvoiceRows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceRow = await _context.InvoiceRow.FindAsync(id);
            if (invoiceRow == null)
            {
                return NotFound();
            }
            ViewData["ArticleId"] = new SelectList(_context.Article, "Id", "Id", invoiceRow.ArticleId);
            return View(invoiceRow);
        }

        // POST: InvoiceRows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArticleId,Quantity,ArticlePrice,RowTotal")] InvoiceRow invoiceRow)
        {
            if (id != invoiceRow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var applicationDbContext = _context.InvoiceRow
                    .Include(i => i.Article);
                    invoiceRow.RowTotal = invoiceRow.Quantity * invoiceRow.ArticlePrice;

                    _context.Update(invoiceRow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceRowExists(invoiceRow.Id))
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
            ViewData["ArticleId"] = new SelectList(_context.Article, "Id", "Id", invoiceRow.ArticleId);
            return View(invoiceRow);
        }

        // GET: InvoiceRows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceRow = await _context.InvoiceRow
                .Include(i => i.Article)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceRow == null)
            {
                return NotFound();
            }

            return View(invoiceRow);
        }

        // POST: InvoiceRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceRow = await _context.InvoiceRow.FindAsync(id);
            _context.InvoiceRow.Remove(invoiceRow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceRowExists(int id)
        {
            return _context.InvoiceRow.Any(e => e.Id == id);
        }
    }
}
