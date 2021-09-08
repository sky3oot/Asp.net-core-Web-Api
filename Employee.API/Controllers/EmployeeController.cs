using Employee.Abstractions.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using Employee.Abstractions.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Abstractions.Services;

namespace Employee.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]


    public class EmployeeController : Controller
    {

        IEmployeeServices _EmployeeServices;

        public EmployeeController(IEmployeeServices EmployeeServices)
        {
            _EmployeeServices = EmployeeServices;
        }

        [HttpPost]
        public ActionResult<List<string>> SaveDetails([FromBody] Employe Employees)
        {

           var result = _EmployeeServices.SaveEmployee(Employees);
            if(result.Count < 1)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
           
        }
        [HttpGet]
        public  IActionResult GetDetails()
        {
            var employees = _EmployeeServices.GetAllEmployees();
            return Ok(employees);
        }
        [HttpPut]
        public IActionResult UpdateDetails([FromBody] Employe Employees)
        {

            var result = _EmployeeServices.UpdateEmployee(Employees);
            if (result.Count < 1)
            {

                return Ok();
            }
            else
            {
                return BadRequest(result);
            }

        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDetails(Guid id)
        {
            _EmployeeServices.DeleteEmployee(id);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(Guid id)
        {

            var employees = _EmployeeServices.GetEmployee(id);
            _EmployeeServices.GetEmployee(id);

            return Ok(employees);
        }
    }
}
