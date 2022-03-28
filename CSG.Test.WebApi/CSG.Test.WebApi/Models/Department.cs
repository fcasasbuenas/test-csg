using System.Collections.Generic;

namespace CSG.Test.WebApi.Models
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}