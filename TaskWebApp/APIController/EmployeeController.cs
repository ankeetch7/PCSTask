using DAL.UOW.IUOW;
using DAL.ViewModels.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskWebApp.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get-all-employees")]
        public async Task<ActionResult<List<EmployeeVM>>> GetAllEmployees()
        {
            var employess = await _unitOfWork.Employees.GetAllEmployees();
            return Ok(employess);
        }

        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            var response = await _unitOfWork.Employees.CreateEmployee(command);
            return Ok();
        }

        [HttpPut("update-employee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
        {
            var response = await _unitOfWork.Employees.UpdateEmployee(command);
            if(response is 0)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpDelete("delete-employee/{Employee_Id}")]
        public async Task<IActionResult> DeletEmployee([FromRoute] Guid Employee_Id)
        {
            var response = await _unitOfWork.Employees.DeleteEmployee(Employee_Id);
            if(response is 0)
                return BadRequest(response);
            return Ok(response);
        }
    }
}
