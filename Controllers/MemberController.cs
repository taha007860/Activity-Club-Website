using ASPDotnetWebApplication.Models;
using ASPDotnetWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity; // Include this for password hashing
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore; // If not already included

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

            // Check if the email already exists in the database
            if (await _context.Members.AnyAsync(m => m.Email == model.Email))
            {
                ViewData["ErrorMessage"] = "An account with this email already exists.";
                return View(model);
            }

            // Check if email, password, or name is null
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.FullName))
            {
                ViewData["ErrorMessage"] = "Please fill in all required fields.";
                return View(model);
            }

            if (!passwordRegex.IsMatch(model.Password!))
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
                    Password = _passwordHasher.HashPassword(new Member(), model.Password!) // Hash the password
                };

                _context.Add(member);
                await _context.SaveChangesAsync();

               
                ModelState.Clear();

                // Redirect to the Login action in MemberController
                return RedirectToAction("Login", "Member");
            }
            catch (Exception)
            {
                ViewData["ErrorMessage"] = "An error occurred while processing your request.";
                return View(model);
            }

        }

        // GET: Member/Login
        public IActionResult Login()
        {
            return View();
        }
        // POST: Member/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Email == model.Email);

            if (member == null || member.Password == null || model.Password == null || member.Email == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            var result = _passwordHasher.VerifyHashedPassword(member, member.Password, model.Password);
            if (result != PasswordVerificationResult.Success)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            // Removed the session-related code

            // Redirect to the home page or dashboard
            return RedirectToAction("Register", "Member");
        }


    }
}
