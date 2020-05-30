using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace ESClient.Models
{
    class Root
    {
        private static HttpClient client = new HttpClient();

        public static async Task<IHtmlDocument> GetHTMLDocument(string urlParams)
        {
            var doc = default(IHtmlDocument);
            using (var stream = await client.GetStreamAsync(new Uri("https://erogamescape.dyndns.org/~ap2/ero/toukei_kaiseki" + urlParams)))
            {
                // AngleSharp.Parser.Html.HtmlParserオブジェクトにHTMLをパースさせる
                var parser = new HtmlParser();
                doc = await parser.ParseDocumentAsync(stream);
            }
            return doc;
        }

        public static List<Game> Games;

        public class Game
        {
            public int Id;
            public string Title;
            public int brandId;
            public string brandName;
            public string OHP;
            public string sellday;
            public string ImgUri;
            public int Median, Average, Count;
            public List<Creator> Gengas, Shinarios;
            public List<Seiyu> Seiyus;
        }

        public class Creator
        {
            public int Id;
            public string Name;
        }

        public class Seiyu : Creator
        {
            public string Role;
            public int Importance; // 0 => Main, 1 => Sub, 2 => Mob
        }
    }
}
