﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMP2019.Data;
using TMP2019.Models.DataModels.TMPHockeyModels;

namespace TMP2019.Controllers.TMPHockeyControllers
{
    public class GameReceiptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameReceiptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GameReceipts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GameReceipt.Include(g => g.Game).Include(g => g.HD1).Include(g => g.HD2).Include(g => g.LD1).Include(g => g.LD2);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WorkReports HttpPost !
        [HttpPost]
        public IActionResult Index(GameReceipt gameReceipt)
        {
            var applicationDbContext = _context.GameReceipt.Include(gr => gr.Game).Include(gr => gr.HD1).Include(g => g.HD2).Include(g => g.LD1).Include(g => g.LD2);
            gameReceipt.HD1TotalFee = gameReceipt.HD1Fee + gameReceipt.HD1TravelKost + gameReceipt.HD1Alowens + gameReceipt.HD1LateGameKost;
            gameReceipt.HD2TotalFee = gameReceipt.HD2Fee + gameReceipt.HD2TravelKost + gameReceipt.HD2Alowens + gameReceipt.HD2LateGameKost;
            gameReceipt.LD1TotalFee = gameReceipt.LD1Fee + gameReceipt.LD1TravelKost + gameReceipt.LD1Alowens + gameReceipt.LD1LateGameKost;
            gameReceipt.LD2TotalFee = gameReceipt.LD2Fee + gameReceipt.LD2TravelKost + gameReceipt.LD2Alowens + gameReceipt.LD2LateGameKost;
            gameReceipt.GameTotalKost = gameReceipt.HD1TotalFee + gameReceipt.HD2TotalFee + gameReceipt.LD1TotalFee + gameReceipt.LD2TotalFee;
            return View(gameReceipt);
        }

        // GET: GameReceipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameReceipt = await _context.GameReceipt
                .Include(g => g.Game)
                .Include(g => g.HD1)
                .Include(g => g.HD2)
                .Include(g => g.LD1)
                .Include(g => g.LD2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameReceipt == null)
            {
                return NotFound();
            }

            return View(gameReceipt);
        }

        // GET: GameReceipts/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: GameReceipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameId,PersonId,PersonId1,PersonId2,PersonId3,HD1Fee,HD1TravelKost,HD1Alowens,HD1LateGameKost,HD1TotalFee,HD2Fee,HD2TravelKost,HD2Alowens,HD2LateGameKost,HD2TotalFee,LD1Fee,LD1TravelKost,LD1Alowens,LD1LateGameKost,LD1TotalFee,LD2Fee,LD2TravelKost,LD2Alowens,LD2LateGameKost,LD2TotalFee,GameTotalKost")] GameReceipt gameReceipt)
        {
            if (ModelState.IsValid)
            {
                var applicationDbContext = _context.GameReceipt.Include(gr => gr.Game).Include(gr => gr.HD1).Include(g => g.HD2).Include(g => g.LD1).Include(g => g.LD2);
                gameReceipt.HD1TotalFee = gameReceipt.HD1Fee + gameReceipt.HD1TravelKost + gameReceipt.HD1Alowens + gameReceipt.HD1LateGameKost;
                gameReceipt.HD2TotalFee = gameReceipt.HD2Fee + gameReceipt.HD2TravelKost + gameReceipt.HD2Alowens + gameReceipt.HD2LateGameKost;
                gameReceipt.LD1TotalFee = gameReceipt.LD1Fee + gameReceipt.LD1TravelKost + gameReceipt.LD1Alowens + gameReceipt.LD1LateGameKost;
                gameReceipt.LD2TotalFee = gameReceipt.LD2Fee + gameReceipt.LD2TravelKost + gameReceipt.LD2Alowens + gameReceipt.LD2LateGameKost;
                gameReceipt.GameTotalKost = gameReceipt.HD1TotalFee + gameReceipt.HD2TotalFee + gameReceipt.LD1TotalFee + gameReceipt.LD2TotalFee;

                _context.Add(gameReceipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", gameReceipt.GameId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", gameReceipt.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", gameReceipt.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", gameReceipt.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", gameReceipt.PersonId3);
            return View(gameReceipt);
        }

        // GET: GameReceipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameReceipt = await _context.GameReceipt.FindAsync(id);
            if (gameReceipt == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", gameReceipt.GameId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", gameReceipt.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", gameReceipt.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", gameReceipt.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", gameReceipt.PersonId3);
            return View(gameReceipt);
        }

        // POST: GameReceipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameId,PersonId,PersonId1,PersonId2,PersonId3,HD1Fee,HD1TravelKost,HD1Alowens,HD1LateGameKost,HD1TotalFee,HD2Fee,HD2TravelKost,HD2Alowens,HD2LateGameKost,HD2TotalFee,LD1Fee,LD1TravelKost,LD1Alowens,LD1LateGameKost,LD1TotalFee,LD2Fee,LD2TravelKost,LD2Alowens,LD2LateGameKost,LD2TotalFee,GameTotalKost")] GameReceipt gameReceipt)
        {
            if (id != gameReceipt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var applicationDbContext = _context.GameReceipt.Include(gr => gr.Game).Include(gr => gr.HD1).Include(g => g.HD2).Include(g => g.LD1).Include(g => g.LD2);
                    gameReceipt.HD1TotalFee = gameReceipt.HD1Fee + gameReceipt.HD1TravelKost + gameReceipt.HD1Alowens + gameReceipt.HD1LateGameKost;
                    gameReceipt.HD2TotalFee = gameReceipt.HD2Fee + gameReceipt.HD2TravelKost + gameReceipt.HD2Alowens + gameReceipt.HD2LateGameKost;
                    gameReceipt.LD1TotalFee = gameReceipt.LD1Fee + gameReceipt.LD1TravelKost + gameReceipt.LD1Alowens + gameReceipt.LD1LateGameKost;
                    gameReceipt.LD2TotalFee = gameReceipt.LD2Fee + gameReceipt.LD2TravelKost + gameReceipt.LD2Alowens + gameReceipt.LD2LateGameKost;
                    gameReceipt.GameTotalKost = gameReceipt.HD1TotalFee + gameReceipt.HD2TotalFee + gameReceipt.LD1TotalFee + gameReceipt.LD2TotalFee;

                    _context.Update(gameReceipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameReceiptExists(gameReceipt.Id))
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
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "GameNumber", gameReceipt.GameId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", gameReceipt.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", gameReceipt.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", gameReceipt.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", gameReceipt.PersonId3);
            return View(gameReceipt);
        }

        // GET: GameReceipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameReceipt = await _context.GameReceipt
                .Include(g => g.Game)
                .Include(g => g.HD1)
                .Include(g => g.HD2)
                .Include(g => g.LD1)
                .Include(g => g.LD2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameReceipt == null)
            {
                return NotFound();
            }

            return View(gameReceipt);
        }

        // POST: GameReceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameReceipt = await _context.GameReceipt.FindAsync(id);
            _context.GameReceipt.Remove(gameReceipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameReceiptExists(int id)
        {
            return _context.GameReceipt.Any(e => e.Id == id);
        }
    }
}