using Microsoft.AspNetCore.Mvc;
using ASPDotnetWebApplication.Models;
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
            // Check if the user is logged in
            if (HttpContext.Session.GetInt32("MemberId") == null)
            {
                // If the user is not logged in, redirect to the Login action in MemberController
                return RedirectToAction("Login", "Member");
            }

            // User is logged in, proceed to fetch events
            var events = _context.Events.ToList(); // Fetch events from the database
            return View(events); // Pass the events to the view
        }
    }
}
