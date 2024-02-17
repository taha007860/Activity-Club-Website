using ASPDotnetWebApplication.Models;
using ASPDotnetWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity; // Include this for password hashing
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ASPDotnetWebApplication.Controllers
{
    public class MemberController : Controller
    {
        private readonly ActivityClubContext _context;
        private readonly PasswordHasher<Member> _passwordHasher;

        public MemberController(ActivityClubContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<Member>();
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
#pragma warning disable SYSLIB1045 // Suppress the warning
            var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{6,}$");
#pragma warning restore SYSLIB1045 // Restore the warning

            if (model.Password == null || !passwordRegex.IsMatch(model.Password))
            {
                ViewData["ErrorMessage"] = "Password must be at least 6 characters long and include at least one uppercase letter, one lowercase letter, one number, and one symbol.";
                return View(model);
            }

            try
            {
                var member = new Member
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Password = _passwordHasher.HashPassword(new Member(), model.Password) // Hash the password
                };

                _context.Add(member);
                await _context.SaveChangesAsync();

                ViewData["SuccessMessage"] = "Registration successful!";
                ModelState.Clear();
                return View();
            }
            catch (Exception)
            {
                ViewData["ErrorMessage"] = "An error occurred while processing your request.";
                return View(model);
            }
        }


    }
}
