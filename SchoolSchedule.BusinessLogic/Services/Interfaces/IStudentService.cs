using SchoolSchedule.BusinessLogic.Dtos;
using SchoolSchedule.BusinessLogic.Requests;

namespace SchoolSchedule.BusinessLogic.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllAsync();
        Task<StudentDto> GetByIdAsync(int id);
        Task<StudentDto> AddAsync(StudentRequest studentRequest);
        Task<StudentDto> UpdateAsync(int id, StudentRequest studentRequest);
        Task<StudentDto> DeleteAsync(int id);
    }
}
