using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2TimerScraper
{
    public static class XpathUtils
    {
        /// <summary>
        /// Xpath string generator that selector that selects by multiple classes
        /// This makes use of Xpath 1.0 methods instead of relying on 2.0 http://stackoverflow.com/a/5449355/1232818
        /// </summary>
        /// <param name="xpath">Preceding Xpath string (e.g. "/div/table")</param>
        /// <param name="classes">An array of classes to search. (e.g. new [] { "button", "enabled" })</param>
        /// <returns></returns>
        public static string XpathSelectByMultipleClasses(string xpath, params string[] classes)
        {
            string result = xpath + "[contains(@class,'";
            for (int i = 0; i <= classes.Length - 1; i++ )
            {
                string classStr = classes[i];
                if (i == classes.Length - 1) //on the last one, close the capture
                {
                    result += classStr + "')]";
                    break;
                }
                result += classStr + "') and contains(@class ,'";
            }
            return result;
        }
    }
}
