using Microsoft.AspNetCore.Mvc;
using SchoolSchedule.BusinessLogic.Requests;
using SchoolSchedule.BusinessLogic.Services.Interfaces;

namespace SchoolSchedule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var schedules = await _scheduleService.GetAllAsync();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var schedule = await _scheduleService.GetByIdAsync(id);

            return Ok(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ScheduleRequest request)
        {
            var createdSchedule = await _scheduleService.AddAsync(request);

            return CreatedAtAction(nameof(GetById), new { id = createdSchedule.Id }, createdSchedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ScheduleRequest request)
        {
            var updatedSchedule = await _scheduleService.UpdateAsync(id, request);

            return Ok(updatedSchedule);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _scheduleService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetByDate(DateTime date)
        {
            var schedules = await _scheduleService.GetByDateAsync(date);

            return Ok(schedules);
        }
    }
}
