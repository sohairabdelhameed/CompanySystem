using CompanySystem.Models;
using CompanySystemBLL.Repository;
using CompanySystemDataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanySystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // Index - List all employees
        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAll();
            return View(employees);
        }

        // Create - Display the form to create an employee
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create - Add a new employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // Details - View an employee's details by id
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeRepository.Get(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // Edit - Display the form to edit an employee
        public IActionResult Edit(int? id)
        {
            var result = Details(id);  // Reuse Details method
            if (result is NotFoundResult)
            {
                return result;
            }

            return View((Employee)((ViewResult)result).Model);
        }

        // POST: Edit - Update an employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _employeeRepository.Update(employee);
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        // Delete - Display the confirmation view to delete an employee
        public IActionResult Delete(int? id)
        {
            var result = Details(id);  // Reuse Details method
            if (result is NotFoundResult)
            {
                return result;
            }

            return View((Employee)((ViewResult)result).Model);
        }

        // POST: Delete - Remove an employee
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee != null)
            {
                _employeeRepository.Delete(employee);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
