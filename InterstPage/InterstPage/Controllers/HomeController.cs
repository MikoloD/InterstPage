using InterstPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InterstPage.Controllers
{
    public class HomeController : Controller
    {
        private List<PhotoModel> CreateModel()
        {
            List<PhotoModel> IntrestList = new List<PhotoModel>()
            {
                new PhotoModel {URL="https://www.muzykotekaszkolna.pl/!data/resources/graphics/co_slychac/Teatr_Wielki_ok.1900.jpg",PhotoDesccription="Architektura"},
                new PhotoModel {URL="https://e-shareef.com/images/portfolio/portfolio-08-large.jpg",PhotoDesccription="Programowanie"},
                new PhotoModel {URL="https://wb713.files.wordpress.com/2015/12/img.jpg",PhotoDesccription="Matematyka"},
                new PhotoModel {URL="https://www.zachod24.pl/wp-content/uploads/sites/5/2020/11/rzad-1918-2020-11-10_13-44-08_611799.jpg",PhotoDesccription="Historia"}
            };
            return IntrestList;
        }
        private readonly ILogger<HomeController> _logger;
        private InterstModel model = new InterstModel();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            model.MyInterstsList = CreateModel();
            return View(model);
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
