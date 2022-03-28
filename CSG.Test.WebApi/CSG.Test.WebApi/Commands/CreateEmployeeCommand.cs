namespace CSG.Test.WebApi.Commands
{
    public class CreateEmployeeCommand
    {
        public string Name { get; set; }
        public long Salary { get; set; }
        public long DepartmentId { get; set; }
    }
}
