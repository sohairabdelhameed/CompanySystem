using CompanySystem.Data.Context;
using CompanySystemBLL.Interface;
using CompanySystemDataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace CompanySystemBLL.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>,IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context) : base(context) { }
        //{
        //    _context = context;
        //}
        public IEnumerable<Employee> SearchByName(string name)
        {
            return _context.Employees.Where(e => e.Name.Contains(name.ToLower()).ToString() == name);

        }

        //    // Add a new employee
        //    public int Add(Employee employee)
        //    {
        //        _context.Employees.Add(employee);
        //        return _context.SaveChanges(); // Returns the number of affected rows
        //    }

        //    // Delete an employee by id
        //    public int Delete(int id)
        //    {
        //        var employee = _context.Employees.Find(id);
        //        if (employee != null)
        //        {
        //            _context.Employees.Remove(employee);
        //            return _context.SaveChanges(); // Returns the number of affected rows
        //        }
        //        return 0; // No employee was found to delete
        //    }

        //    public int Delete(Employee Entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    // Get all employees
        //    public IEnumerable<Employee> GetAll()
        //    {
        //        return _context.Employees.ToList();
        //    }

        //    // Get a single employee by id
        //    public Employee Get(int id)
        //    {
        //        return _context.Employees.Find(id); // Returns null if no employee is found
        //    }

        //    // Update an existing employee
        //    public int Update(Employee employee)
        //    {
        //        var existingEmployee = _context.Employees.Find(employee.Id);
        //        if (existingEmployee != null)
        //        {
        //            _context.Entry(existingEmployee).CurrentValues.SetValues(employee);
        //            return _context.SaveChanges(); // Returns the number of affected rows
        //        }
        //        return 0; // No employee was found to update
        //    }

        //    Employee IGenericRepository<Employee>.Add(Employee entity)
        //    {
        //        throw new NotImplementedException();
        //    }
    }

}
