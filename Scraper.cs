using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.MobileControls;
using System.Windows.Documents;
using WebScraperProj.Data;

namespace WebScraperProj.Workers
{
    class Scraper
    {
        private object matchedPart;

        //rivate object matchedPart;

        //private object scrappedElements;

        public List<string> Scrape(ScrapeCriteria scrapeCriteria)
        {
            List<string> scrapedElements = new List<string>();

            MatchCollection matches = Regex.Matches(scrapeCriteria.Data, scrapeCriteria.Regex, scrapeCriteria.RegexOption);

            foreach (Match match in matches)
            {
                if (!scrapeCriteria.Parts.Any())
                {
                    scrapedElements.Add(match.Groups[0].Value);
                    //internal object Scrape(ScrapeCriteria scrapeCriteria)
                    //{
                    //    throw new NotImplementedException();
                    //}
                }
                else
                {
                    foreach (var part in scrapeCriteria.Parts)
                    {
                        Match matchedpart = Regex.Match(match.Groups[0].Value, part.Regex, part.RegexOption);
                      if (matchedPart.Success) scrapedElements.Add(matchedPart.Groups[1].Vlaue);
                    }
                }
            }
            return scrapedElements;
        }
    }
}
