
using EmployeeTry.Models;
using EmployeeTry.Services;

namespace EmployeeTry.Interface
{
    public interface IEmployee
    {
        public void AddEmployee(EmployeeModel emp);

        public EmployeeModel GetEmployee(int id);
        public string GetEmployeePhone(int id);
    }
}
