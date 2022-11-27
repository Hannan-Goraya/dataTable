using Dapper;
using dataTable.data;
using dataTable.Dtos;
using dataTable.Models;
using dataTable.Models.Dt;
using dataTable.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace dataTable.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IEmployeeService _emp;
        private readonly IbaseRepo _dapper;


        public HomeController( IEmployeeService emp, IbaseRepo dapper)
        {
         
          
            _emp = emp;

            _dapper = dapper;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult AddOrEdit(int EmployeeId = 0)
        {
            if (EmployeeId == 0)
            {
                return View(new Employee());
            }
            else
            {
                return View(_emp.GetEmpById(EmployeeId));
            }

         
        }
        [HttpPost]
        public IActionResult AddOrEdit(int EmployeeId, Employee employee)
        {
            if (EmployeeId == 0)
            {
                 _emp.AddEmp(employee);
                return Json(new { success = true, message = "Saved Successfully" });
            }
            else
            {
                _emp.EditEmployee(EmployeeId, employee);
            }

            return View();


        }






        [HttpPost]
        public IActionResult Detail(int EmployeeId)
        {
           
            var emp = _emp.GetEmpById(EmployeeId);

            return View(emp);
        }

        [HttpPost]
        public IActionResult Delete(int EmployeeId)
        {
            if (EmployeeId != 0)
                _emp.DeleteEmp(EmployeeId);

            else
                return BadRequest();

            return View();
        }








        //[HttpPost]
        //public JsonResult GetEmployeeList()
        //{
        //    int totalRecord = 0;
        //    int filterRecord = 0;
        //    var draw = Request.Form["draw"].FirstOrDefault();
        //    var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        //    var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        //    var searchValue = Request.Form["search[value]"].FirstOrDefault();
        //    int pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
        //    int skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
        //    var data = _context.Set<Employee>().AsQueryable();

        //    totalRecord = data.Count();

        //    if (!string.IsNullOrEmpty(searchValue))
        //    {
        //        data = data.Where(x => x.EmployeeFirstName.ToLower().Contains(searchValue.ToLower()) || 
        //        x.EmployeeLastName.ToLower().Contains(searchValue.ToLower()) || 
        //        x.Designation.ToLower().Contains(searchValue.ToLower()) || 
        //        x.Salary.ToString().ToLower().Contains(searchValue.ToLower()));
        //    }

        //    filterRecord = data.Count();



        //    var empList = data.Skip(skip).Take(pageSize).ToList();
        //    var returnObj = new
        //    {
        //        draw = draw,
        //        recordsTotal = totalRecord,
        //        recordsFiltered = filterRecord,
        //        data = empList
        //    };

        //    return Json(returnObj);
        //}















        public JsonResult spGetEmp()
        {

            var request = new DataTableRequest();

            request.Draw = Convert.ToInt32(Request.Form["draw"].FirstOrDefault());
            request.Start = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            request.Length = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            request.Search = new DataTableSearch()
            {
                Value = Request.Form["search[value]"].FirstOrDefault()
            };
            request.Order = new DataTableOrder[] {
            new DataTableOrder()
            {
                Dir = Request.Form["order[0][dir]"].FirstOrDefault(),
                Column = Convert.ToInt32(Request.Form["order[0][column]"].FirstOrDefault())
            }};

            return Json(_emp.GetEmployeesAsync(request).Result);

        }


        public IActionResult SPDT()
        {
            return View();
        }



        public JsonResult GetEmpDT()
        {

            var request = new DtRequest();



            request.draw = Convert.ToInt32(Request.Form["draw"]);

            request.SortExpression = Request.Form["order[0][dir]"] ;
            request.StartRowIndex = Convert.ToInt32(Request.Form["start"]);
            request.PageSize = Convert.ToInt32(Request.Form["length"]);
            request.SearchText = Request.Form["search[value]"];


            var data = _emp.GetAllDt(request).Result;


            return Json(data);
            


                
           
            

        }






    }
}
