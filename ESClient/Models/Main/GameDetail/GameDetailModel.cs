using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ESClient.Models.Main.GameDetail
{
    class GameDetailModel
    {
        public static async Task GetGameInfo(int GameId)
        {
            var game = new Models.Root.Game();
            try
            {
                var doc = await Models.Root.GetHTMLDocument("/game.php?game=" + GameId.ToString());
                // 詳細情報の取得
                var game_title = doc.GetElementById("game_title");
                game.Title = game_title.GetElementsByTagName("a")[0].InnerHtml;
                var soft_title = doc.GetElementById("soft-title");
                game.brandId = int.Parse(soft_title.GetElementsByTagName("a")[0].GetAttribute("href").Replace("brand.php?brand=", ""));
                game.brandName = soft_title.GetElementsByTagName("a")[0].InnerHtml;
                game.sellday = soft_title.GetElementsByTagName("a")[1].InnerHtml;
                game.OHP = game_title.GetElementsByTagName("a")[0].GetAttribute("href");
                game.Median = int.Parse(doc.GetElementById("median").GetElementsByTagName("td")[0].InnerHtml);
                game.Average = int.Parse(doc.GetElementById("average").GetElementsByTagName("td")[0].InnerHtml);
                game.Count = int.Parse(doc.GetElementById("count").GetElementsByTagName("td")[0].InnerHtml);
                game.ImgUri = doc.GetElementById("main_image").GetElementsByTagName("img")[0].GetAttribute("src");
                game.Gengas = getCreators(doc.GetElementById("genga").GetElementsByTagName("td")[0]);
                game.Shinarios = getCreators(doc.GetElementById("shinario").GetElementsByTagName("td")[0]);
                game.Seiyus = getSeiyus(doc.GetElementById("seiyu").GetElementsByTagName("td")[0]);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("error occured");
            }
        }

        private static List<Root.Creator> getCreators(IElement elements)
        {
            var creators = new List<Root.Creator>();
            var aTags = elements.GetElementsByTagName("a");
            for (int i = 0; i < aTags.Length; i++)
            {
                try
                {
                    var creator = new Root.Creator();
                    creator.Id = int.Parse(aTags[i].GetAttribute("href").Replace("creater.php?creater=", ""));
                    creator.Name = aTags[i].InnerHtml;
                    creators.Add(creator);
                }
                catch
                {

                }
            }
            return creators;
        }

        private static List<Root.Seiyu> getSeiyus(IElement elements)
        {
            var seiyus = new List<Root.Seiyu>();
            var aTags = elements.GetElementsByTagName("a");
            var spanTags = elements.GetElementsByTagName("span");
            for (int i = 0; i < aTags.Length; i++)
            {
                try
                {
                    var seiyu = new Root.Seiyu();
                    seiyu.Id = int.Parse(aTags[i].GetAttribute("href").Replace("creater.php?creater=", ""));
                    seiyu.Name = aTags[i].InnerHtml;
                    seiyu.Role = spanTags[i].InnerHtml;
                    var color = spanTags[i].GetAttribute("style");
                    // 色で役のimportanceを判別
                    if (color.Contains("bold"))
                    {
                        seiyu.Importance = 0;
                    }
                    else if (color.Contains("black"))
                    {
                        seiyu.Importance = 1;
                    }
                    else
                    {
                        seiyu.Importance = 2;
                    }
                    seiyus.Add(seiyu);
                }
                catch
                {

                }
            }
            return seiyus;
        }
    }
}
