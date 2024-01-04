using Microsoft.AspNetCore.Mvc;
using SMSApp.Data;
using SMSApp.Models;
using System.Diagnostics;

namespace SMSApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context, ILogger<StudentController> logger)
        {
            _context = context;
            _logger = logger;
        }



        public IActionResult Create()
        {
            var viewModel = new Student
            {
                Qualifications = new List<Qualification> { new Qualification() }
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student viewModel)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    DOB = viewModel.DOB,
                    Gender = viewModel.Gender,
                    EmailId = viewModel.EmailId,
                    MobileNo = viewModel.MobileNo,
                    Qualifications = viewModel.Qualifications.Select(q => new Qualification
                    {
                        Course = q.Course,
                        University = q.University,
                        Year = q.Year,
                        Percentage = q.Percentage
                    }).ToList()
                };

                _context.Add(student);
                await _context.SaveChangesAsync();

                return RedirectToAction("RegistrationSuccess", new { studentId = student.StudentId }); // Redirect to a success page or the student list page
            }

            // If the ModelState is not valid, redisplay the form with validation errors
            return View(viewModel);
        }


        public IActionResult RegistrationSuccess(int studentId)
        {
            ViewBag.StudentId = studentId;
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}