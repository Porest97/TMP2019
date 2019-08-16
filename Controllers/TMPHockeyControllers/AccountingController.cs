using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMP2019.Data;

namespace TMP2019.Controllers.TMPHockeyControllers
{
    public class AccountingController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AccountingController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult AccountingIndex()
        {
            return View();
        }

        public IActionResult GameReceipts()
        {
            return View();
        }

    //    // GET: GameReceipts
    //    public async Task<IActionResult> GameReceipts(string sortOrder, string searchString, string searchString1)
    //    {
    //        ViewData["ArenaSortParm"] = sortOrder == "Arena" ? "arena_desc" : "Arena";
    //        ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
    //        ViewData["StatusSortParm"] = sortOrder == "Status" ? "status_desc" : "Status";
    //        ViewData["GameCategorySortParm"] = sortOrder == "GameCategory" ? "gameCategory_desc" : "GameCategory";
    //        ViewData["CurrentFilter"] = searchString;
    //        ViewData["CurrentFilter1"] = searchString1;
    //        var gameReceipts = from g in _context.GameReceipt
    //                    .Include(g => g.Game)
    //                    .Include(g => g.HD1)
    //                    .Include(g => g.HD1Alowens)
    //                    .Include(g => g.HD1Fee)
    //                    .Include(g => g.HD1LateGameKost)
    //                    .Include(g => g.HD1TotalFee)
    //                    .Include(g => g.HD1TravelKost)
    //                    .Include(g => g.HD2)
    //                    .Include(g => g.HD2Alowens)
    //                    .Include(g => g.HD2Fee)
    //                    .Include(g => g.HD2LateGameKost)
    //                    .Include(g => g.HD2TotalFee)
    //                    .Include(g => g.HD2TravelKost)
    //                    .Include(g => g.LD1)
    //                    .Include(g => g.LD1Alowens)
    //                    .Include(g => g.LD1Fee)
    //                    .Include(g => g.LD1LateGameKost)
    //                    .Include(g => g.LD1TotalFee)
    //                    .Include(g => g.LD1TravelKost)
    //                    .Include(g => g.LD2)
    //                    .Include(g => g.LD2Alowens)
    //                    .Include(g => g.LD2Fee)
    //                    .Include(g => g.LD2LateGameKost)
    //                    .Include(g => g.LD2TotalFee)
    //                    .Include(g => g.LD2TravelKost)
    //                    .Include(g => g.Game.GameStatus)
    //                           select g;
    //        if (!String.IsNullOrEmpty(searchString))
    //        {
    //            gameReceipts = gameReceipts.Where(g => g.HD1.FullName.Contains(searchString)
    //            );
    //        }

        //        switch (sortOrder)
        //        {
        //            case "gameNumber_desc":
        //                gameReceipts = gameReceipts.OrderByDescending(g => g.Game.GameNumber).Where(g => g.Id != 0 && g.Game.GameStatusId == 3);
        //                break;
        //            case "GameNumber":
        //                gameReceipts = gameReceipts.OrderBy(g => g.Game.GameNumber).Where(g => g.Id != 0 && g.Game.GameStatusId == 3);
        //                break;
        //            case "Date":
        //                gameReceipts = gameReceipts.OrderBy(g => g.Game.GameDateTime).Where(g => g.Id != 0 && g.Game.GameStatusId == 3);
        //                break;
        //            case "date_desc":
        //                gameReceipts = gameReceipts.OrderByDescending(g => g.Game.GameDateTime).Where(g => g.Id != 0 && g.Game.GameStatusId == 3);
        //                break;
        //            case "status_desc":
        //                gameReceipts = gameReceipts.OrderByDescending(g => g.Game.GameStatus.GameStatusName);
        //                break;
        //            case "Status":
        //                gameReceipts = gameReceipts.OrderBy(g => g.Game.GameStatus.GameStatusName);
        //                break;
        //            //case "gameCategory_desc":
        //            //    games = games.OrderByDescending(g => g.GameCategory.GameCategoryName).Where(g => g.Id != 0 && g.GameStatusId == 1);
        //            //    break;
        //            //case "GameCategory":
        //            //    games = games.OrderBy(g => g.GameCategory.GameCategoryName).Where(g => g.Id != 0 && g.GameStatusId == 1);
        //            //    break;
        //            default:
        //                gameReceipts = gameReceipts.OrderByDescending(g => g.Game.GameNumber).Where(g => g.Id != 0 && g.Game.GameStatusId == 3);
        //                break;
        //        }
        //        return View(await gameReceipts.AsNoTracking().ToListAsync());
        //    }
        //    //var applicationDbContext = _context.GameReceipt.Include(g => g.Game).Include(g => g.HD1).Include(g => g.HD2).Include(g => g.LD1).Include(g => g.LD2);
        //    //return View(await applicationDbContext.ToListAsync());
        }
    }
