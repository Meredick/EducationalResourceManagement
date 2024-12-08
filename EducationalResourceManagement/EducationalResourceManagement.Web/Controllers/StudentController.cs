using Microsoft.AspNetCore.Mvc;
using EducationalResourceManagement.Domain.Entities;
using EducationalResourceManagement.Infrastructure.Data;

namespace EducationalResourceManagement.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly EducationalResourceContext _context;

        public StudentController(EducationalResourceContext context)
        {
            _context = context;
        }

        // Lista de estudiantes
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // Crear un nuevo estudiante
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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

        // Ver detalles de un estudiante
        public IActionResult Details(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // Editar un estudiante
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // Eliminar un estudiante
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

