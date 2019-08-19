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
    public class InvoicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Invoice.Include(i => i.Customer).Include(i => i.Row1).Include(i => i.Row10).Include(i => i.Row2).Include(i => i.Row3).Include(i => i.Row4).Include(i => i.Row5).Include(i => i.Row6).Include(i => i.Row7).Include(i => i.Row8).Include(i => i.Row9).Include(i => i.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.Customer)
                .Include(i => i.Row1)
                .Include(i => i.Row10)
                .Include(i => i.Row2)
                .Include(i => i.Row3)
                .Include(i => i.Row4)
                .Include(i => i.Row5)
                .Include(i => i.Row6)
                .Include(i => i.Row7)
                .Include(i => i.Row8)
                .Include(i => i.Row9)
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName");
            ViewData["InvoiceRowId"] = new SelectList(_context.InvoiceRow, "Id", "Id");
            ViewData["InvoiceRowId9"] = new SelectList(_context.InvoiceRow, "Id", "Id");
            ViewData["InvoiceRowId1"] = new SelectList(_context.InvoiceRow, "Id", "Id");
            ViewData["InvoiceRowId2"] = new SelectList(_context.InvoiceRow, "Id", "Id");
            ViewData["InvoiceRowId3"] = new SelectList(_context.InvoiceRow, "Id", "Id");
            ViewData["InvoiceRowId4"] = new SelectList(_context.InvoiceRow, "Id", "Id");
            ViewData["InvoiceRowId5"] = new SelectList(_context.InvoiceRow, "Id", "Id");
            ViewData["InvoiceRowId6"] = new SelectList(_context.InvoiceRow, "Id", "Id");
            ViewData["InvoiceRowId7"] = new SelectList(_context.InvoiceRow, "Id", "Id");
            ViewData["InvoiceRowId8"] = new SelectList(_context.InvoiceRow, "Id", "Id");
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvoceHeader,CompanyId,CompanyId1,InvoiceDate,Maturity,PaymentTerms,InvoiceRowId,InvoiceRowId1,InvoiceRowId2,InvoiceRowId3,InvoiceRowId4,InvoiceRowId5,InvoiceRowId6,InvoiceRowId7,InvoiceRowId8,InvoiceRowId9,InvoceFooter")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "ComapnyName", invoice.CompanyId);
            ViewData["InvoiceRowId"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId);
            ViewData["InvoiceRowId9"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId9);
            ViewData["InvoiceRowId1"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId1);
            ViewData["InvoiceRowId2"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId2);
            ViewData["InvoiceRowId3"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId3);
            ViewData["InvoiceRowId4"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId4);
            ViewData["InvoiceRowId5"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId5);
            ViewData["InvoiceRowId6"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId6);
            ViewData["InvoiceRowId7"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId7);
            ViewData["InvoiceRowId8"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId8);
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId1);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "ComapnyName", invoice.CompanyId);
            ViewData["InvoiceRowId"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId);
            ViewData["InvoiceRowId9"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId9);
            ViewData["InvoiceRowId1"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId1);
            ViewData["InvoiceRowId2"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId2);
            ViewData["InvoiceRowId3"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId3);
            ViewData["InvoiceRowId4"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId4);
            ViewData["InvoiceRowId5"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId5);
            ViewData["InvoiceRowId6"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId6);
            ViewData["InvoiceRowId7"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId7);
            ViewData["InvoiceRowId8"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId8);
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId1);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvoceHeader,CompanyId,CompanyId1,InvoiceDate,Maturity,PaymentTerms,InvoiceRowId,InvoiceRowId1,InvoiceRowId2,InvoiceRowId3,InvoiceRowId4,InvoiceRowId5,InvoiceRowId6,InvoiceRowId7,InvoiceRowId8,InvoiceRowId9,InvoceFooter")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "ComapnyName", invoice.CompanyId);
            ViewData["InvoiceRowId"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId);
            ViewData["InvoiceRowId9"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId9);
            ViewData["InvoiceRowId1"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId1);
            ViewData["InvoiceRowId2"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId2);
            ViewData["InvoiceRowId3"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId3);
            ViewData["InvoiceRowId4"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId4);
            ViewData["InvoiceRowId5"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId5);
            ViewData["InvoiceRowId6"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId6);
            ViewData["InvoiceRowId7"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId7);
            ViewData["InvoiceRowId8"] = new SelectList(_context.InvoiceRow, "Id", "Id", invoice.InvoiceRowId8);
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId1);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.Customer)
                .Include(i => i.Row1)
                .Include(i => i.Row10)
                .Include(i => i.Row2)
                .Include(i => i.Row3)
                .Include(i => i.Row4)
                .Include(i => i.Row5)
                .Include(i => i.Row6)
                .Include(i => i.Row7)
                .Include(i => i.Row8)
                .Include(i => i.Row9)
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.Id == id);
        }
    }
}
