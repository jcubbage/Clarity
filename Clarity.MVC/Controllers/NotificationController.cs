using Clarity.Core.Data;
using Clarity.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clarity.MVC.Controllers
{
    public class NotificationController : Controller
    {
        private readonly ApplicationDbContext _context;

        
        public NotificationController(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Notifications.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.Notifications.Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Notification model)
        {
            if (ModelState.IsValid)
            {
                _context.Notifications.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
