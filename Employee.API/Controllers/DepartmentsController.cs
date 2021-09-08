using Employee.Abstractions.Models;
using Employee.Abstractions.Repository;
using Employee.Abstractions.Services;
using Employee.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        IEmployeeServices _EmployeeServices;

        public DepartmentsController(IEmployeeServices EmployeeServices)
        {
            _EmployeeServices = EmployeeServices;
        }

        [HttpPost]

        public IActionResult SaveDetails([FromBody] Department departments)
        {
            
          var result =  _EmployeeServices.SaveDepartment(departments);
            if(result.Count > 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
           

        }

        [HttpGet]

        public IActionResult GetDetails()
        {
            var departments = _EmployeeServices.GetAllDepartment();
            
            return Ok(departments);

        }

        [HttpPut]

        public IActionResult UpdateDetails([FromBody] Department departments)
        {
           var result = _EmployeeServices.UpdateDepartment(departments);
            if(result.Count > 1)
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

            _EmployeeServices.DeleteDepartment(id);

            return Ok();

        }

        [HttpGet]
        [Route("{id}")]

        public IActionResult GetOne(Guid id)
        {
            var department = _EmployeeServices.GetDepartment(id);
            _EmployeeServices.GetDepartment(id);
            return Ok(department);

        }
    }
}
