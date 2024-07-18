using SchoolSchedule.BusinessLogic.Dtos;
using SchoolSchedule.BusinessLogic.Requests;

namespace SchoolSchedule.BusinessLogic.Services.Interfaces
{
    public interface IStudentGroupService
    {
        Task<List<StudentGroupDto>> GetAllAsync();
        Task<StudentGroupDto> GetByIdAsync(int id);
        Task<StudentGroupDto> AddAsync(StudentGroupRequest request);
        Task<StudentGroupDto> UpdateAsync(int id, StudentGroupRequest request);
        Task<StudentGroupDto> DeleteAsync(int id);
    }
}
