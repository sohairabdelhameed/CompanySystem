using CompanySystem.Data.Context;
using CompanySystemBLL.Interface;
using CompanySystemDataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace CompanySystemBLL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add a new entity
        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);  // Add entity to the context
            _dbContext.SaveChanges();         // Save changes to the database
            return entity;                    // Return the newly added entity
        }

        // Delete an entity
        public int Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);   // Remove the entity
            return _dbContext.SaveChanges();      // Save changes and return affected rows
        }

        // Get a single entity by ID
        public T Get(int id)
        {
            return _dbContext.Set<T>().Find(id);  // Find and return the entity by its ID
        }

        // Get all entities
        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();  // Return all entities as a list
        }

        // Update an existing entity
        public int Update(T entity)
        {
            var existingEntity = _dbContext.Set<T>().Find(entity.Id);  // Find the existing entity
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);  // Update entity values
                return _dbContext.SaveChanges();                                   // Save changes and return affected rows
            }
            return 0; // Return 0 if the entity was not found
        }
    }
}
