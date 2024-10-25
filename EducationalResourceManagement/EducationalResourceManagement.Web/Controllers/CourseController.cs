using EducationalResourceManagement.Application.Services;
using EducationalResourceManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EducationalResourceManagement.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: Course/Index
        public IActionResult Index()
        {
            var courses = _courseService.GetAllCourses();
            return View(courses);
        }

        // GET: Course/Details/5
        public IActionResult Details(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseService.CreateCourse(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Course/Edit/5
        public IActionResult Edit(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _courseService.UpdateCourse(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Course/Delete/5
        public IActionResult Delete(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
