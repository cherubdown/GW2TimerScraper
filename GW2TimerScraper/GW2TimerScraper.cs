using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace GW2TimerScraper
{
    public static class GW2TimerScraper
    {
        public static bool Run()
        {
            ScheduleScraper scraper = new ScheduleScraper();
            Dictionary<DateTime, string> UpdatedList = scraper.UpdateSchedule();
            return true;
        }
    }
}
