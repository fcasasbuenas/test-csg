namespace CSG.Test.WebApi.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Salary { get; set; }
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}