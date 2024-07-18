using SchoolSchedule.DataAccess.Entities;

namespace SchoolSchedule.DataAccess.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student> AddAsync(Student student);
        Task<Student> UpdateAsync(Student student);
        Task<Student> DeleteAsync(Student student);
    }
}
