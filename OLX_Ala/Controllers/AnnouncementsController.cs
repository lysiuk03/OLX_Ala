using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Data;
using DataAccess.Data.Entities;
using OLX_Ala.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using OLX_Ala.Models;
using System.Drawing;
using OLX_Ala.Helpers;

namespace OLX_Ala.Controllers
{
    [Authorize]
    public class AnnouncementsController : Controller
    {
        private readonly AlaOlxDbContext ctx;
        private readonly IFileService fileService;

        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public AnnouncementsController(AlaOlxDbContext ctx, IFileService fileService)
        {
            this.ctx = ctx;
            this.fileService = fileService;
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
        public async Task <IActionResult> Create(CreateAnnouncementModel model)
        {
            //announcement.UserId = CurrentUserId;
            if (!ModelState.IsValid)
            {
                LoadSelect();
                return View(model);
            }
            var announcement = new Announcement()
            {
                Name = model.Name,
                Price = model.Price,
                InStock = model.InStock,
                ImageURL = await fileService.SaveAnnouncementImage(model.ImageFile) ,
                CategoryId = model.CategoryId,
                RegionId = model.RegionId,
                Discount = model.Discount,
                Description = model.Description,
                ContactName = model.ContactName,
                Phone = model.Phone
            };

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