using UMS.Data;
using UMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UMS.ViewModels;

namespace UMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext context;

        public StudentController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var students = await context.Students.Include(m => m.Department).ToListAsync();
            return View(students);
        }

        public async Task<IActionResult> Create()
        {
            StudentViewModel studentViewModel = new StudentViewModel()
            {
                Student = new Student(),
                Department = new Department(),
                Departments = await context.Departments.ToListAsync()
            };

            return View(studentViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await context.Students.AddAsync(student);
                await context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }

            StudentViewModel studentViewModel = new StudentViewModel()
            {
                Student = new Student(),
                Department = new Department(),
                Departments = await context.Departments.ToListAsync()
            };

            return View(studentViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var findById = await context.Students.SingleOrDefaultAsync(m => m.Id == id);

            if (findById == null)
            {
                return NotFound();
            }

            StudentViewModel studentViewModel = new StudentViewModel()
            {
                Student = findById,
                Department = new Department(),
                Departments = await context.Departments.ToListAsync()
            };

            return View(studentViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentViewModel studentViewModel, int? id)
        {
            if (ModelState.IsValid)
            {
                var findById = await context.Students.FindAsync(id);
                findById.FirstName = studentViewModel.Student.FirstName;
                findById.LastName = studentViewModel.Student.LastName;
                findById.DepartmentId = studentViewModel.Student.DepartmentId;
                findById.Semester = studentViewModel.Student.Semester;
                await context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }

            StudentViewModel studentVM = new StudentViewModel()
            {
                Student = new Student(),
                Department = new Department(),
                Departments = await context.Departments.ToListAsync()
            };

            return View(studentVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var findById = await context.Students.SingleOrDefaultAsync(m => m.Id == id);

            if (findById == null)
            {
                return NotFound();
            }

            StudentViewModel studentViewModel = new StudentViewModel()
            {
                Student = findById,
                Department = new Department(),
                Departments = await context.Departments.ToListAsync()
            };

            return View(studentViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(StudentViewModel studentViewModel, int? id)
        {
            if (ModelState.IsValid)
            {
                var findById = await context.Students.FindAsync(id);
                context.Students.Remove(findById);
                await context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }

            StudentViewModel studentVM = new StudentViewModel()
            {
                Student = new Student(),
                Department = new Department(),
                Departments = await context.Departments.ToListAsync()
            };

            return View(studentVM);
        }

    }
}
