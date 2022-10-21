using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIBKMNET_API.Context;
using SIBKMNET_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        MyContext myContext;

        public EmployeesController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        [HttpGet]
        public ActionResult Get()
        {
           var data = myContext.Employees.ToList();
            return Ok(new { status = 200, message = "data has been collected", data = data });
       }

        [HttpGet("{id}")]
        public ActionResult Get( int id)
        {
            var data = myContext.Employees.Find(id);
             return Ok(new { status = 200, message = "data has been collected", data = data });
        }
        [HttpPost]
        public ActionResult Post(ViewModels.EmployeeVM employeeVM)
        {
            Employee employee = new Employee(employeeVM);
            myContext.Employees.Add(employee);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { status = 200, message = " data has been inserted" });
            return BadRequest(new { status = 400, message = "data has not been inserted" });
        }

        [HttpPut]
        public ActionResult Put(ViewModels.EmployeeVM employeeVM)
        {
            Employee employee = new Employee(employeeVM);
            myContext.Employees.Update(employee);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { satatus = 200, message = " data has been update" });
            return BadRequest(new { status = 400, message = "data has not been update" });
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var data = myContext.Employees.Find(id);
            myContext.Employees.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { satatus = 200, message = " data has been delete" });
            return BadRequest(new { status = 400, message = "data has not been delete" });
        }
    }
}
