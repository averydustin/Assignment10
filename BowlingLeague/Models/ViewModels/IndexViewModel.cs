using System;
using System.Collections.Generic;
//Index View Model to work with page numbers, categories, and bowlers
namespace BowlingLeague.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<models.Bowler> BowlingLeague { get; set; }

        public PageNumberingInfo pageNumberingInfo { get; set; }
        public string Team { get; set; }
    }
}
