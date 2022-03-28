using CSG.Test.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace CSG.Test.WebApi.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly CsgDbContext _csgDbContext;

        public EmployeeRepository(CsgDbContext csgDbContext)
        {
            _csgDbContext = csgDbContext;
        }

        public void Add(Employee entity)
        {
            _csgDbContext.Employees.Add(entity);
            _csgDbContext.SaveChanges();
        }

        public void Delete(Employee entity)
        {
            _csgDbContext.Employees.Remove(entity);
            _csgDbContext.SaveChanges();
        }

        public Employee Get(long id)
        {
            return _csgDbContext.Employees.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _csgDbContext.Employees;
        }

        public void Update(Employee dbEntity, Employee entity)
        {
            dbEntity.DepartmentId = entity.DepartmentId;
            dbEntity.Name = entity.Name;
            dbEntity.Salary = entity.Salary;

            _csgDbContext.SaveChanges();
        }
    }
}