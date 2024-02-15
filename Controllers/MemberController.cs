using ASPDotnetWebApplication.Models;
using ASPDotnetWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Include this for logging
using System;

namespace ASPDotnetWebApplication.Controllers
{
    public class MemberController : Controller
    {
        private readonly ActivityClubContext _context;
        private readonly ILogger<MemberController> _logger; // Logger

        public MemberController(ActivityClubContext context, ILogger<MemberController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Member/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Member/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            

            try
            {
                var member = new Member
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Password = model.Password // Consider hashing the password
                };

                _context.Add(member);
                await _context.SaveChangesAsync();

                ViewData["SuccessMessage"] = "Registration successful!";
                _logger.LogInformation("Member registered successfully");

                ModelState.Clear();
                return View();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Error occurred while registering member");

                // Handle the exception
                // You can add a ViewData item to show an error message in the view, or handle it in another way
                ViewData["ErrorMessage"] = "An error occurred while processing your request.";
                return View(model);
            }
        }
    }
}
