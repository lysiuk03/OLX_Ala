using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLX_Ala.Data;
using OLX_Ala.Helpers;
using System.Text.Json;

namespace OLX_Ala.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly AlaOlxDbContext ctx;

        public FavouriteController(AlaOlxDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult Index()
        {
            List<int> ids = HttpContext.Session.Get<List<int>>("favourites_items");
            List<Announcement> ann = new List<Announcement>();
            if(ids != null)
            {
                ann = ctx.Announcements.Where(x => ids.Contains(x.Id)).ToList();
            }
            return View(ann);
        }
        public IActionResult Add(int id)
        {
            List<int> ids = HttpContext.Session.Get<List<int>>("favourites_items");
            if (ids == null)
            {
                ids = new List<int>();
            }
            ids.Add(id);
            HttpContext.Session.Set("favourites_items", ids);
            return RedirectToAction("Index", "Home");
        }
       
        public IActionResult Unfavourit(int id)
        {
            List<int> ids = HttpContext.Session.Get<List<int>>("favourites_items");
            if (ids != null)
            {
                ids.Remove(id);

                HttpContext.Session.Set("favourites_items", ids);
            }
            return RedirectToAction("Index");
        }
    }
}
