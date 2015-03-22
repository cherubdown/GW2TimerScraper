using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using HtmlAgilityPack;

namespace GW2TimerScraper
{
    class ScheduleScraper
    {
        private const string _wikiUrl = "http://wiki.guildwars2.com/wiki/World_boss";
        public static WebClient Client { get; set; }
        public static HtmlDocument Doc { get; set; }

        Dictionary<DateTime, string> UpdatedList { get; set; }

        public ScheduleScraper()
        {
            UpdatedList = new Dictionary<DateTime, string>();
        }

        public Dictionary<DateTime, string> UpdateSchedule()
        {
            try
            {
                DownloadPageAndLoadDoc();
                UpdatedList = ParseDoc();
            }
            catch (Exception e)
            {
            }

            return UpdatedList;
        }

        private void DownloadPageAndLoadDoc()
        {
            Client = new WebClient();   //webclient allows us to download documents
            Doc = new HtmlDocument();   //The meat of the HtmlAgilityPack
            string html = Client.DownloadString(_wikiUrl);  //download from the wiki
            Doc.LoadHtml(html);                             //load the document so we can start parsing
        }

        private Dictionary<DateTime, string> ParseDoc()
        {
            Dictionary<DateTime, string> result = new Dictionary<DateTime, string>();
            string[] classes = "mech1 mw-collapsible mw-collapsed table".Split(' ');
            HtmlNode tableNode = Doc.DocumentNode.SelectSingleNode(XpathUtils.XpathSelectByMultipleClasses("//table", classes));

            HtmlNodeCollection rows = tableNode.SelectNodes("tr");
            foreach (HtmlNode row in rows)
            {
                HtmlNode dateNode = row.SelectSingleNode(@".//span[@class=""utc-auto-convert""]");
                HtmlNode eventNode = row.SelectSingleNode(@".//a");
                if (dateNode != null && eventNode != null)
                {
                    Console.WriteLine(dateNode.InnerHtml + " ---- " + eventNode.InnerHtml);
                    //string date = row.SelectSingleNode(@"span[class='utc-auto-convert']").InnerHtml;
                    //string eventName = row.SelectSingleNode(@"td[2]").InnerHtml;
                    //Console.WriteLine(date);
                }
            }

            return result;
        }
    }
}
