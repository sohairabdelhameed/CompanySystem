using CompanySystem.Data.Context;
using CompanySystem.Models;
using CompanySystemBLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanySystemBLL.Repository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;

        public DepartmentRepository(AppDbContext context) : base(context) { }


        //// Add a new department
        //public int Add(Department entity)
        //{
        //    _dbContext.Departments.Add(entity);
        //    return _dbContext.SaveChanges();
        //}

        //// Delete a department
        //public int Delete(Department entity)
        //{
        //    _dbContext.Departments.Remove(entity);
        //    return _dbContext.SaveChanges();
        //}

        //// Get a department by its id
        //public Department Get(int? id)
        //{
        //    return _dbContext.Departments.Find(id);
        //}

        //public Department Get(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //// Get all departments
        //public IEnumerable<Department> GetAll()
        //{
        //    return _dbContext.Departments.ToList();
        //}

        //// Update a department
        //public int Update(Department entity)
        //{
        //    _dbContext.Departments.Update(entity);
        //    return _dbContext.SaveChanges();
        //}

        //Department IGenericRepository<Department>.Add(Department entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
