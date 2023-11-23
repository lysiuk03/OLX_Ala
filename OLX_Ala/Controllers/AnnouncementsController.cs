using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Data;
using DataAccess.Data.Entities;
using OLX_Ala.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace OLX_Ala.Controllers
{
    [Authorize]
    public class AnnouncementsController : Controller
    {
        private readonly AlaOlxDbContext ctx;
        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public AnnouncementsController(AlaOlxDbContext ctx)
        {
            this.ctx = ctx;
        }
        private void LoadSelect()
        {
            this.ViewBag.Categories = new SelectList(ctx.Categorys.ToList(), "Id", "Name");
            this.ViewBag.Cities = new SelectList(ctx.Regions.ToList(), "Id", "Name");
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                var announcements = ctx.Announcements.ToList();
                return View(announcements);
            }
            else
            {
                var announcements = ctx.Announcements
                    .Where(a => a.UserId == CurrentUserId)
                    .ToList();

                return View(announcements);
            }
        }

        public IActionResult Edit(int id)
        {
            var item = ctx.Announcements.Find(id);
            if (item == null) return NotFound();
            LoadSelect();
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Announcement announcement)
        {
            ctx.Announcements.Update(announcement);
            ctx.SaveChanges();
            return RedirectToAction("Index");
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
            announcement.UserId = CurrentUserId;
            if (!ModelState.IsValid)
            {
                LoadSelect();
                return View(announcement);
            }
           
            ctx.Announcements.Add(announcement);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles ="Admin")]
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
            var item = ctx.Announcements
                   .Include(a => a.category)
                   .Include(a => a.region)
                   .FirstOrDefault(a => a.Id == id);
            if (item == null) return NotFound();
            return View("Details", item);
        }
    }
}