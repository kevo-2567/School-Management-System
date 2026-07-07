using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentsController(SchoolDbContext context)
        {
            _context = context;
        }

        // Student List
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // Display Create Form
        public IActionResult Create()
        {
            return View();
        }

        // Save Student
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }
    }
}