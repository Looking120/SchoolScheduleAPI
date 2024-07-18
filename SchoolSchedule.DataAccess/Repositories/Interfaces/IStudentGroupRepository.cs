using SchoolSchedule.DataAccess.Entities;

namespace SchoolSchedule.DataAccess.Repositories.Interfaces;

public interface IStudentGroupRepository
{
    Task<StudentGroup> GetByIdAsync(int id);
    Task<List<StudentGroup>> GetAllGroupsAsync();
    Task<StudentGroup?> GetByNameAsync(string groupName);
    Task<StudentGroup> AddAsync(StudentGroup studentGroup);
    Task<StudentGroup> UpdateAsync(StudentGroup studentGroup);
    Task<StudentGroup> DeleteAsync(StudentGroup studentGroup);
}
