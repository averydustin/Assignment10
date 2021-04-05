using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BowlingLeague.Models;
using BowlingLeague.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using BowlingLeague.Models.ViewModels;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index(long? team, string teamName, int pageNum = 0)
        {
            int pageSize = 5;
            ViewBag.Title = (teamName == null ? "Bowler Contact Info" : teamName);

            return View(new IndexViewModel
            {
                BowlingLeague = (context.Bowlers
                    .Where(m => m.TeamId == team || team == null)
                    .OrderBy(m => m.BowlerFirstName)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()),

                pageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    //If no team is selected then get the full count. Otherwise count the number from the selected team
                    TotalNumItems = (team == null ? context.Bowlers.Count() :
                    context.Bowlers.Where(x => x.TeamId == team).Count())
                },
                Team = teamName
            }) ;

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
