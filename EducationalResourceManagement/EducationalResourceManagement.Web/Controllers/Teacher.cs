using Microsoft.AspNetCore.Mvc;
using EducationalResourceManagement.Infrastructure.Data;
using EducationalResourceManagement.Domain.Entities;


namespace EducationalResourceManagement.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly EducationalResourceContext _context;

        public TeacherController(EducationalResourceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teachers = _context.Teachers.ToList();
            return View(teachers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        public IActionResult Details(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null)
                return NotFound();

            return View(teacher);
        }
    }
}

