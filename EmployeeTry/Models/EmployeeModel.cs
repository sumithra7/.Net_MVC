using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTry.Models
{
    public class EmployeeModel
    {
        
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public string Address { get; set; }
        [Precision(18, 2)]

        public decimal? basic { get; set; }
        [Precision(18, 2)]

        public decimal? NetSalary { get; set; }
        
        public string Phone { get; set; }
        public string EmployeeType { get; set; }
        

    }
}
