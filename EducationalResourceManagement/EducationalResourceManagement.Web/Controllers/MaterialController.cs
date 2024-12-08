using Microsoft.AspNetCore.Mvc;
using EducationalResourceManagement.Domain.Entities;
using EducationalResourceManagement.Infrastructure.Data;

namespace EducationalResourceManagement.Web.Controllers
{
    public class MaterialController : Controller
    {
        private readonly EducationalResourceContext _context;

        public MaterialController(EducationalResourceContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            var materials = _context.Materials.ToList();
            return View(materials);
        }

        public IActionResult Create()
        {
            var courses = _context.Courses.ToList();
            ViewData["Courses"] = courses;

            var material = new Material();
            return View(material);
        }

        [HttpPost]
        public IActionResult Create(Material material)
        {
            if (ModelState.IsValid)
            {
                material.UploadDate = DateTime.Now;
                _context.Materials.Add(material);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        public IActionResult Details(int id)
        {
            var material = _context.Materials.Find(id);
            if (material == null)
                return NotFound();

            return View(material);
        }

        public IActionResult Edit(int id)
        {
            var material = _context.Materials.Find(id);
            if (material == null)
                return NotFound();

            return View(material);
        }

        [HttpPost]
        public IActionResult Edit(Material material)
        {
            if (ModelState.IsValid)
            {
                _context.Materials.Update(material);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        
        public IActionResult Delete(int id)
        {
            var material = _context.Materials.Find(id);
            if (material == null)
                return NotFound();

            return View(material);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var material = _context.Materials.Find(id);
            if (material != null)
            {
                _context.Materials.Remove(material);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
