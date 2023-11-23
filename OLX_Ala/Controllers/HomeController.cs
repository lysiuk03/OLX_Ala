using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OLX_Ala.Data;
using OLX_Ala.Models;
using System.Diagnostics;

namespace OLX_Ala.Controllers
{
    public class HomeController : Controller
    {
        private readonly AlaOlxDbContext ctx;

        public HomeController(AlaOlxDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult Index()
        {
           
            return View(ctx.Announcements.ToList());
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