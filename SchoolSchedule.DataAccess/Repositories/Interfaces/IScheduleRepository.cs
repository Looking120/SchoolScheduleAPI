using SchoolSchedule.DataAccess.Entities;

namespace SchoolSchedule.DataAccess.Repositories.Interfaces
{
    public interface IScheduleRepository
    {
        Task<Schedule> GetByIdAsync(int id);
        Task<List<Schedule>> GetAllAsync();
        Task<Schedule> AddAsync(Schedule schedule);
        Task<Schedule> UpdateAsync(Schedule schedule);
        Task<Schedule> DeleteAsync(Schedule schedule);
        Task<List<Schedule>> GetByDateAsync(DateTime date);
    }
}
