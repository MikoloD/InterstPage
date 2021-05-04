using InterstPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InterstPage.Controllers
{
    public class HomeController : Controller
    {
        private List<PhotoModel> CreateModel()
        {
            string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum";
            List<PhotoModel> IntrestList = new List<PhotoModel>()
            {
                new PhotoModel {
                    URL="https://e-shareef.com/images/portfolio/portfolio-08-large.jpg",
                    PhotoDesccription="Programowanie",
                    LongerDescrition=loremIpsum
                },
                new PhotoModel {
                    URL="https://wb713.files.wordpress.com/2015/12/img.jpg",
                    PhotoDesccription="Matematyka",
                    LongerDescrition=loremIpsum
                },
                new PhotoModel {
                    URL="https://www.zachod24.pl/wp-content/uploads/sites/5/2020/11/rzad-1918-2020-11-10_13-44-08_611799.jpg",
                    PhotoDesccription="Historia",
                    LongerDescrition=loremIpsum
                },
                new PhotoModel {
                    URL="https://www.muzykotekaszkolna.pl/!data/resources/graphics/co_slychac/Teatr_Wielki_ok.1900.jpg",
                    PhotoDesccription="Architektura",
                    LongerDescrition=loremIpsum
                }
            };
            return IntrestList;
        }
        List<string> Urls = new List<string>()
        {
            "https://news.google.com/rss?hl=pl&gl=PL&ceid=PL:pl",
            "https://wydarzenia.interia.pl/polska/feed"
        };
        private InterstModel model = new InterstModel();
        public IActionResult Index()
        {
            List<RssItem> RssList = new List<RssItem>();
            foreach(var elem in Urls)
            {
                var xml = XElement.Load(elem);
                var items = xml.Descendants("item").Select(n => new RssItem
                {
                    Title = n.Element("title").Value,
                    Description = n.Element("description").Value
                }).ToList();
                RssList.AddRange(items);
            }
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                int index = rnd.Next(RssList.Count());
                model.RssItems.Add(RssList[index]);
                RssList.RemoveAt(index);
            }
            model.MyInterstsList = CreateModel();
            return View(model);
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
