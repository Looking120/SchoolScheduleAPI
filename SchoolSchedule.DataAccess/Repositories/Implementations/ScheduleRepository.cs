using Microsoft.EntityFrameworkCore;
using SchoolSchedule.DataAccess.Data;
using SchoolSchedule.DataAccess.Entities;
using SchoolSchedule.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSchedule.DataAccess.Repositories.Implementations
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ApplicationDbContext _db;

        public ScheduleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Schedule> GetByIdAsync(int id)
        {
            return await _db.Schedules.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Schedule>> GetAllAsync()
        {
            return await _db.Schedules.AsNoTracking().ToListAsync();
        }

        public async Task<Schedule> AddAsync(Schedule schedule)
        {
            _db.Schedules.Add(schedule);
            await _db.SaveChangesAsync();
            return schedule;
        }

        public async Task<Schedule> UpdateAsync(Schedule schedule)
        {
            _db.Schedules.Update(schedule);
            await _db.SaveChangesAsync();
            return schedule;
        }

        public async Task<Schedule> DeleteAsync(Schedule schedule)
        {
            _db.Schedules.Remove(schedule);
            await _db.SaveChangesAsync();
            return schedule;
        }

        public async Task<List<Schedule>> GetByDateAsync(DateTime date)
        {
            return await _db.Schedules.AsNoTracking().Where(s => s.Date.Date == date.Date).ToListAsync();
        }
    }
}
