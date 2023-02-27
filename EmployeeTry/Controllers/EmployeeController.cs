using EmployeeTry.Interface;
using EmployeeTry.Models;
using EmployeeTry.Services;
using EmployeeTry.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTry.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee Iemployee;
        private readonly AEmployee Aemployee;


        public EmployeeController(IEmployee _employee, AEmployee _aemp )
        {
            Iemployee = _employee;
            Aemployee = _aemp;
            
        }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public JsonResult CalculateEmployeeSalary(EmployeeModel emp, string type)
        {
            var salary = Aemployee.CalculateSalary(emp.basic, type );
            return Json(salary);
        }

        [HttpPost]
        public JsonResult GetEmployeeData(int id)
        {
            try
            {
                var data = Iemployee.GetEmployee(id);
                
                return Json(new { Message = "Success", EmployeeDeatils = data });


            }
            catch (Exception ex)
            {
                return Json(new { Message = ex.ToString() });

            }
            
        }

        [HttpPost]
        public JsonResult GetEmployeePhoneNumber(int id)
        {

            try
            {
                var data = Iemployee.GetEmployeePhone(id);
                return Json(new { Message = "Success", EmployeePhone = data });

            }
            catch(Exception ex)
            {
                return Json(new { Message = ex.ToString() });
            }
            
        }

        [HttpPost]
        public JsonResult AddNewEmployee(EmployeeModel emp)
        {
            try {
                Iemployee.AddEmployee(emp);
                
                return Json(new { Message = "Success" });
            } catch (Exception ex) {
                return Json(new { Message = ex.ToString()});
            }
            
        }
    }
}
