using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OLX_Ala.Data;
using OLX_Ala.Data.Entities;

namespace OLX_Ala.Controllers
{
    public class AnnouncementsController : Controller
    {
         AlaOlxDbContext ctx=new AlaOlxDbContext();

        public IActionResult Index()
        {
            var announcement = ctx.Announcements.ToList();
            return View(announcement);
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