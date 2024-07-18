using Microsoft.AspNetCore.Mvc;
using MobilePhoneWebApp.BusinessLogic.Exceptions;
using SchoolSchedule.BusinessLogic.Dtos;
using SchoolSchedule.BusinessLogic.Requests;
using SchoolSchedule.BusinessLogic.Services.Interfaces;

namespace SchoolSchedule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGroupController : Controller
    {
        private readonly IStudentGroupService _studentGroupService;

        public StudentGroupController(IStudentGroupService studentGroupService)
        {
            _studentGroupService = studentGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studentGroups = await _studentGroupService.GetAllAsync();
            return Ok(studentGroups);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var studentGroup = await _studentGroupService.GetByIdAsync(id);
            if (studentGroup == null)
            {
                return NotFound();
            }
            return Ok(studentGroup);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentGroupRequest request)
        {
            var createdStudentGroup = await _studentGroupService.AddAsync(request);
            
            return CreatedAtAction(nameof(GetById), new { id = createdStudentGroup.Id }, createdStudentGroup);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentGroupRequest request)
        {
            var updatedStudentGroup = await _studentGroupService.UpdateAsync(id, request);
            
            return Ok(updatedStudentGroup);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentGroupService.DeleteAsync(id);
            
            return NoContent();
        }
    }
}
