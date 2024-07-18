using SchoolSchedule.BusinessLogic.Dtos;
using SchoolSchedule.BusinessLogic.Requests;

namespace SchoolSchedule.BusinessLogic.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<List<ScheduleDto>> GetAllAsync();
        Task<ScheduleDto> GetByIdAsync(int id);
        Task<ScheduleDto> AddAsync(ScheduleRequest scheduleRequest);
        Task<ScheduleDto> UpdateAsync(int id, ScheduleRequest scheduleRequest);
        Task<ScheduleDto> DeleteAsync(int id);
        Task<List<ScheduleDto>> GetByDateAsync(DateTime date);
    }
}
