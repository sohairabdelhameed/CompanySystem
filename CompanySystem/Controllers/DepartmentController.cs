using CompanySystem.Models;
using CompanySystemBLL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CompanySystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository departmentRepository;

        public DepartmentController(DepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        // Index - List all departments
        public IActionResult Index()
        {
            var departments = departmentRepository.GetAll();
            return View(departments);
        }

        // Create - Display the form to create a department
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create - Add a new department
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentRepository.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // Details - View a department's details by id
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = departmentRepository.Get(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // Edit - Display the form to edit a department
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = departmentRepository.Get(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Edit - Update a department
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                departmentRepository.Update(department);
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // Delete - Display the confirmation view to delete a department
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = departmentRepository.Get(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Delete - Remove a department
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = departmentRepository.Get(id);
            if (department != null)
            {
                departmentRepository.Delete(department);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
