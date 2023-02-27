using EmployeeTry.Data;
using EmployeeTry.Interface;
using EmployeeTry.Models;
using EmployeeTry.Services;
using Microsoft.AspNetCore.Http;
using System.Xml;

namespace EmployeeTry.Services
{
    public class EmployeeClass : AEmployee, IEmployee
    {

       // private static List<EmployeeModel> employee = new List<EmployeeModel>();
        private readonly ILogger<EmployeeClass> _logger;
        private readonly EmployeeContext _context;

        public EmployeeClass(ILogger<EmployeeClass> logger, EmployeeContext context) {
            _logger = logger;
            _context = context;
        }

        public void AddEmployee(EmployeeModel emp)
        {
            try {
                emp.NetSalary = CalculateSalary(emp.basic, emp.EmployeeType);
                //employee.Add(emp);
                _context.Employees.Add(emp);
                _context.SaveChanges();
                //_logger.LogInformation("Information:Added with Id " + emp.Id, emp);
                //_logger.LogError("Error:Added with Id " + emp.Id, emp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:Added with Id " + emp.EmployeeId, emp);
            }
           
          
        }   


        public EmployeeModel GetEmployee(int id)
        {
            var employee = _context.Employees.ToList();

            foreach ( var e in employee)
            {
                if (e.EmployeeId == id)
                {
                    return e;
                }
            }
            return null;
        }

        public string GetEmployeePhone(int id)
        {
            var employee = _context.Employees.ToList();
            foreach (var e in employee)
            {
                if (e.EmployeeId == id)
                {
                    return e.Phone;
                }
            }
            return "No such Id";
        }
    }


}