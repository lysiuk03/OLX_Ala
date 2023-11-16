using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OLX_Ala.Data;
using OLX_Ala.Data.Entities;

namespace OLX_Ala.Controllers
{
    public class AnnouncementsController : Controller
    {
         AlaOlxDbContext ctx=new AlaOlxDbContext();
        private void LoadSelect()
        {
            this.ViewBag.Categories = new SelectList(ctx.Categorys.ToList(), "Id", "Name");
            this.ViewBag.Cities = new SelectList(ctx.Regions.ToList(), "Id", "Name");
        }

        public IActionResult Index()
        {
            var announcement = ctx.Announcements.ToList();
            return View(announcement);
        }
        [HttpGet]
        public IActionResult Create()
        {
            LoadSelect();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                LoadSelect();
                return View(announcement);
            }
            ctx.Announcements.Add(announcement);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var item = ctx.Announcements.Find(id);
            if (item == null) return NotFound();
            ctx.Announcements.Remove(item);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var item = ctx.Announcements.Find(id);
            if (item == null) return NotFound();
            return View("Details", item);
        }
    }
}