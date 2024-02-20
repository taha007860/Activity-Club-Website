using Microsoft.AspNetCore.Mvc;
using ASPDotnetWebApplication.Models; // Adjust the namespace based on your project
using System.Linq;
namespace ASPDotnetWebApplication.Controllers
{
    public class EventController : Controller
    {
        private readonly ActivityClubContext _context; // Assuming you're using Entity Framework

        public EventController(ActivityClubContext context)
        {
            _context = context;
        }

        public IActionResult ListOfEvents()
        {
            var events = _context.Events.ToList(); // Fetch events from the database
            return View(events); // Pass the events to the view
        }
    }
}
