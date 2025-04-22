using Clarity.Core.Data;
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
    }
}
