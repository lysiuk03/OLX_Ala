using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OLX_Ala.Data;
using OLX_Ala.Helpers;
using System.Security.Claims;

namespace OLX_Ala.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly AlaOlxDbContext ctx;
        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public OrdersController(AlaOlxDbContext ctx) {
            this.ctx = ctx;
        }
        public IActionResult Index()
        {
           // var items=ctx.Orders.Where(x=>x.UserId == CurrentUserId).ToList();
            var orders = ctx.Orders
        .Include(o => o.announcement) // Завантажити пов'язане оголошення
        .Where(x => x.UserId == CurrentUserId)
        .ToList();

            return View(orders);
        }
        public IActionResult Create(int id)
        {
            var order = new Order()
            {
                 UserId=CurrentUserId,
                 AnnouncementId=id,
                 Created=DateTime.Now
            };
                ctx.Orders.Add(order);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
