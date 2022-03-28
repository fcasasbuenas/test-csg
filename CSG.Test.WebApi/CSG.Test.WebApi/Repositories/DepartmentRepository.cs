using CSG.Test.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace CSG.Test.WebApi.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly CsgDbContext _csgDbContext;

        public DepartmentRepository(CsgDbContext csgDbContext)
        {
            _csgDbContext = csgDbContext;
        }

        public void Add(Department entity)
        {
            _csgDbContext.Add(entity);
            _csgDbContext.SaveChanges();
        }

        public void Delete(Department entity)
        {
            _csgDbContext.Remove(entity);
            _csgDbContext.SaveChanges();
        }

        public Department Get(long id)
        {
            return _csgDbContext.Departments.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Department> GetAll()
        {
            return _csgDbContext.Departments;
        }

        public void Update(Department dbEntity, Department entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Location = entity.Location;

            _csgDbContext.SaveChanges();
        }
    }
}