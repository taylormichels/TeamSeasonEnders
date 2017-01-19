using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;
using System.Web.Http;
using System.Text.RegularExpressions;

namespace TeamSeasonEnders.API
{
    public class DataParserController : ApiController
    {
        // GET: DataParser
        [System.Web.Http.HttpGet]
        public ActionResult Index()
        {
            foreach (string url in yahooUrls.Values)
            {
                HtmlDocument doc = new HtmlWeb().Load(url);
                var pre = doc.DocumentNode.SelectNodes("//pre").FirstOrDefault();
                var splits = Regex.Split(pre.InnerHtml, "\r\n|\r|\n");
                int year = 0;
                int rival = 0;
                foreach (var split in splits)
                {
                    var match = Regex.Match(split, "(\\d{4}) -- (defeated|lost)\\s([a-zA-Z]*),\\s(\\d-\\d),\\s(.*)");
                    if (match.Success)
                    {
                        year = int.Parse(match.Groups[0].Value);
                        rival = 0;//"TODO";
                    }

                }
                //var matches = Regex.Matches(pre.InnerHtml, "\\d{4} -- (defeated|lost).*");
                //foreach (var match in matches)
                //{
                //    var y = match;
                //}
                //var x = pre;
            }

            return new JsonResult();
        }

        public Dictionary<int, string> yahooUrls = new Dictionary<int, string>
        {
            {3, "http://sports.yahoo.com/nhl/news?slug=detroitpost" },
            {13,  "https://sports.yahoo.com/nhl/news?slug=nyrangerspost" },
            {1,  "http://sports.yahoo.com/nhl/news?slug=bostonpost" }
        };

        public Dictionary<string, int> teamLookup = new Dictionary<string, int>
        {
            { "N.Y. Americans", -1},
            { "Montreal Maroons", -1 },
            { "Hartford", -1 },
            {"Montreal Wanderers", -1 },
            { "N.Y. Islanders",  13},
            { "NY Islanders",  13},
            {  "N.Y. Rangers",  14},
            { "NY Rangers", 14 }

        };
    }
}