using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SMSApp.Data;
using SMSApp.Models;
using System.Security.Claims;
using System.Data.Entity;

namespace SMSApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context, ILogger<AdminController> logger)
        {
            _context = context;
            _logger = logger;
        }



        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Implement admin login logic (check username and password)
            var admin = _context.Admins.FirstOrDefault(a => a.Username == username);

            if (admin != null)
            {
                var passwordHasher = new PasswordHasher<Admin>();
                var result = passwordHasher.VerifyHashedPassword(null, admin.PasswordHash, password);

                if (result == PasswordVerificationResult.Success)
                {
                    // Admin authenticated, redirect to admin dashboard
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.Username),
                new Claim(ClaimTypes.Role, "Admin")
                // Add more claims as needed
            };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Dashboard");
                }
            }

            // Authentication failed, return to login page with an error message
            ViewBag.Error = "Invalid username or password";
            return View();
        }


        [Authorize]
        public IActionResult Dashboard()
        {
            var submittedForms = _context.Students.ToList();
            //foreach (var student in submittedForms)
            //{
            //    _context.Entry(student).Collection(s => s.Qualifications).Load();
            //}
            return View(submittedForms);

        }

        [HttpGet]
        public IActionResult LoadQualifications(int studentId)
        {
            var qualifications = _context.Qualifications
    .Where(q => q.StudentId == studentId)
    .ToList();
            return PartialView("_QualificationsPartial", qualifications);
        }


        private string ComputeHash(string input)
        {
            var passwordHasher = new PasswordHasher<Admin>();
            return passwordHasher.HashPassword(null, input);
        }
    }
}
