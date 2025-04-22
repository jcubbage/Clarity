using System.Threading.Tasks;
using Clarity.Core.Data;
using Clarity.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Clarity.MVC.Controllers.Api
{
    // NOTE!!! since should have security controls to control who can query and create notices!!!!!
    // AUTHORIZE needs to be created here.
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private ApplicationDbContext _context;

        public NotificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        

        // GET: api/<NotificationsController>
        [HttpGet]
        public async Task<IEnumerable<Notification>> Get()
        {
            var model = await _context.Notifications.Where(x => x.Pending).ToListAsync();
            return model;
        }


        // GET api/<NotificationsController>/5
        [HttpGet("{id}")]
        public async Task<Notification> Get(int id)
        {
            var model = await _context.Notifications.Where(x => x.Id == id).FirstOrDefaultAsync();
            return model;
        }

        // POST api/<NotificationsController>
        [HttpPost]
        public async Task<Notification> Post([FromBody] Notification submittedNotification)
        {
            var newNotification = new Notification();
            newNotification.Sender = submittedNotification.Sender;
            newNotification.Recipient = submittedNotification.Recipient;
            newNotification.Subject = submittedNotification.Subject;
            newNotification.Body = submittedNotification.Body;

            if(ModelState.IsValid)
            {
                _context.Notifications.Add(newNotification);
                await _context.SaveChangesAsync();
                return newNotification;
            }
            return submittedNotification;
        }
    }
}
