using DAL.UOW.IUOW;
using DAL.ViewModels.EmpQualification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskWebApp.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeQualificationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeQualificationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        [HttpGet("get-employee-qualification/{Employee_Id}")]
        public async Task<ActionResult<List<EmployeeQualificationVM>>> GetEmployeeQualification([FromRoute] Guid Employee_Id)
        {
            var response = await _unitOfWork.EmployeeQualifications.GetEmployeeQualification(Employee_Id);
            return Ok(response);
        }

        [HttpPost("update-employee-qualification")]
        public async Task<IActionResult> UpdateEmployeeQualification(UpdateEmployeeQualificationCommand command)
        {
            var response = await _unitOfWork.EmployeeQualifications.UpdateEmployeeQualification(command);
            if(response == 0)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpDelete("delete-employee-qualification/{Employee_Id}/{Q_Id}")]
        public async Task<IActionResult> DeleteEmployeeQualification([FromRoute] Guid Employee_Id, Guid Q_Id)
        {
            var response = await _unitOfWork.EmployeeQualifications.DeleteEmployeeQualification(Employee_Id, Q_Id);
            if(response is 0)
                return BadRequest(response);
            return Ok(response);
        }
    }
}
