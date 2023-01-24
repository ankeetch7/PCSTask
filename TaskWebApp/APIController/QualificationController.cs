using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DAL.UOW.IUOW;
using DAL.ViewModels.Qualification;

namespace TaskWebApp.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public QualificationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        [HttpGet("get-all-qualification")]
        public async Task<ActionResult<List<QualificationVM>>> GetAllQualification()
        {
            var qualificationLists = await _unitOfWork.Qualifications.GetAllQualifications();
            return Ok(qualificationLists);
        }

        [HttpPost("create-qualification")]
        public async Task<IActionResult> CreateQualification([FromBody] CreateQualificationCommand command)
        {
            var value = await _unitOfWork.Qualifications.CreateQualification(command);
            return Ok(value);
        }
        [HttpPut("update-qualificaiton")]
        public async Task<IActionResult> UpdateQualification([FromBody] UdateQualificationCommand command)
        {
            var value = await _unitOfWork.Qualifications.UpdateQualification(command);
            if(value is 0)
                return BadRequest(value);
            return Ok(value);
        }
        [HttpDelete("delete-qualification/{Q_Id}")]
        public async Task<IActionResult> DeleteQualification([FromRoute]Guid Q_Id)
        {
            var value = await _unitOfWork.Qualifications.DeleteQualification(Q_Id);
            if (value is 0)
                return BadRequest(value);
            return Ok(value);
        }
            
    }
}
