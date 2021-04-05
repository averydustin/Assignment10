using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BowlingLeague.models;
using Microsoft.AspNetCore.Mvc;

namespace BowlingLeague.Components
{
    public class TeamViewComponent: ViewComponent
    {
        private BowlingLeagueContext context;
        public TeamViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }
        public IViewComponentResult Invoke()
        {

            return View(context.Teams
                .Distinct()
                .OrderBy(x => x));
        }
       
    }
}
