using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Exceptions;
using SchoolSchedule.BusinessLogic.Dtos;
using SchoolSchedule.BusinessLogic.Requests;
using SchoolSchedule.BusinessLogic.Services.Interfaces;
using SchoolSchedule.DataAccess.Entities;
using SchoolSchedule.DataAccess.Repositories.Interfaces;

namespace SchoolSchedule.BusinessLogic.Services.Implemantation
{
    public class StudentGroupService : IStudentGroupService
    {
        private readonly IStudentGroupRepository _studentGroupRepository;
        private readonly IMapper _mapper;

        public StudentGroupService(IStudentGroupRepository studentGroupRepository, IMapper mapper)
        {
            _studentGroupRepository = studentGroupRepository;
            _mapper = mapper;
        }

        public async Task<StudentGroupDto> AddAsync(StudentGroupRequest request)
        {
            var studentGroupEntity = await _studentGroupRepository.AddAsync(_mapper.Map<StudentGroup>(request));
            
            return _mapper.Map<StudentGroupDto>(studentGroupEntity);
        }

        public async Task<StudentGroupDto> DeleteAsync(int id)
        {
            var studentGroupEntity = await _studentGroupRepository.GetByIdAsync(id);
            if (studentGroupEntity is null)
            {
                throw new NotFoundException($"Student group with id {id} not found.");
            }

            var deletedStudentGroup = await _studentGroupRepository.DeleteAsync(studentGroupEntity);

            return _mapper.Map<StudentGroupDto>(deletedStudentGroup);
        }

        public async Task<List<StudentGroupDto>> GetAllAsync()
        {
            var studentGroups = await _studentGroupRepository.GetAllGroupsAsync();

            return _mapper.Map<List<StudentGroupDto>>(studentGroups);
        }

        public async Task<StudentGroupDto> GetByIdAsync(int id)
        {
            var studentGroup = await _studentGroupRepository.GetByIdAsync(id);

            return _mapper.Map<StudentGroupDto>(studentGroup);
        }

        public async Task<StudentGroupDto> UpdateAsync(int id, StudentGroupRequest request)
        {
            var existingStudentGroupEntity = await _studentGroupRepository.GetByIdAsync(id);
            if (existingStudentGroupEntity is null)
            {
                throw new NotFoundException($"Student group with id {id} not found.");
            }

            _mapper.Map(request, existingStudentGroupEntity);
            var updatedStudentGroup = await _studentGroupRepository.UpdateAsync(existingStudentGroupEntity);
            
            return _mapper.Map<StudentGroupDto>(updatedStudentGroup);
        }
    }
}