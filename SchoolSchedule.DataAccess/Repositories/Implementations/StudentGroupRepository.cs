using Microsoft.EntityFrameworkCore;
using SchoolSchedule.DataAccess.Data;
using SchoolSchedule.DataAccess.Entities;
using SchoolSchedule.DataAccess.Repositories.Interfaces;

namespace SchoolSchedule.DataAccess.Repositories.Implementations
{
    public class StudentGroupRepository : IStudentGroupRepository
    {
        private readonly ApplicationDbContext _db;

        public StudentGroupRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<StudentGroup> GetByIdAsync(int id)
        {
            return await _db.StudentGroups.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<StudentGroup>> GetAllGroupsAsync()
        {
            return await _db.StudentGroups.AsNoTracking().ToListAsync();
        }

        public async Task<StudentGroup> AddAsync(StudentGroup studentGroup)
        {
            _db.StudentGroups.Add(studentGroup);
            await _db.SaveChangesAsync();
            return studentGroup;
        }

        public async Task<StudentGroup> UpdateAsync(StudentGroup studentGroup)
        {
            _db.StudentGroups.Update(studentGroup);
            await _db.SaveChangesAsync();
            return studentGroup;
        }

        public async Task<StudentGroup> DeleteAsync(StudentGroup studentGroup)
        {
            _db.StudentGroups.Remove(studentGroup);
            await _db.SaveChangesAsync();
            return studentGroup;
        }

        public async Task<StudentGroup?> GetByNameAsync(string groupName)
        {
            return await _db.StudentGroups.FirstOrDefaultAsync(g => g.GroupName == groupName);
        }
    }
}
