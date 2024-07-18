using Microsoft.EntityFrameworkCore;
using SchoolSchedule.DataAccess.Data;
using SchoolSchedule.DataAccess.Entities;
using SchoolSchedule.DataAccess.Repositories.Interfaces;

namespace SchoolSchedule.DataAccess.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _db.Students.Include(g => g.StudentGroup).AsNoTracking().ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _db.Students.Include(g => g.StudentGroup)
                .AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student> AddAsync(Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();

            return student;
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            _db.Students.Update(student);
            await _db.SaveChangesAsync();

            return student;
        }

        public async Task<Student> DeleteAsync(Student student)
        {
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();

            return student;
        }
    }
}
