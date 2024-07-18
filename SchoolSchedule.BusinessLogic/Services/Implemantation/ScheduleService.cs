using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Exceptions;
using SchoolSchedule.BusinessLogic.Dtos;
using SchoolSchedule.BusinessLogic.Requests;
using SchoolSchedule.BusinessLogic.Services.Interfaces;
using SchoolSchedule.DataAccess.Entities;
using SchoolSchedule.DataAccess.Repositories.Interfaces;

namespace SchoolSchedule.BusinessLogic.Services.Implementations
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public async Task<ScheduleDto> AddAsync(ScheduleRequest request)
        {
            var scheduleEntity = await _scheduleRepository.AddAsync(_mapper.Map<Schedule>(request));

            return _mapper.Map<ScheduleDto>(scheduleEntity);
        }

        public async Task<ScheduleDto> DeleteAsync(int id)
        {
            var scheduleLooked = await _scheduleRepository.GetByIdAsync(id);
            if (scheduleLooked is null)
            {
                throw new NotFoundException("This schedule does not exist");
            }

            var deletedSchedule = await _scheduleRepository.DeleteAsync(scheduleLooked);

            return _mapper.Map<ScheduleDto>(deletedSchedule);
        }

        public async Task<List<ScheduleDto>> GetAllAsync()
        {
            var schedules = await _scheduleRepository.GetAllAsync();
            if (schedules is null)
            {
                throw new NotFoundException("There are no schedules available");
            }

            return _mapper.Map<List<ScheduleDto>>(schedules);
        }

        public async Task<ScheduleDto> GetByIdAsync(int id)
        {
            var scheduleLooked = await _scheduleRepository.GetByIdAsync(id);
            if (scheduleLooked is null)
            {
                throw new NotFoundException("This schedule does not exist");
            }

            return _mapper.Map<ScheduleDto>(scheduleLooked);
        }

        public async Task<ScheduleDto> UpdateAsync(int id, ScheduleRequest request)
        {
            var existingSchedule = await _scheduleRepository.GetByIdAsync(id);
            if (existingSchedule is null)
            {
                throw new NotFoundException("This schedule does not exist");
            }

            _mapper.Map(request, existingSchedule);
            var updatedSchedule = await _scheduleRepository.UpdateAsync(existingSchedule);

            return _mapper.Map<ScheduleDto>(updatedSchedule);
        }

        public async Task<List<ScheduleDto>> GetByDateAsync(DateTime date)
        {
            var schedules = await _scheduleRepository.GetByDateAsync(date);
            if (schedules is null)
            {
                throw new NotFoundException("No schedules found for the specified date");
            }

            return _mapper.Map<List<ScheduleDto>>(schedules);
        }
    }
}
