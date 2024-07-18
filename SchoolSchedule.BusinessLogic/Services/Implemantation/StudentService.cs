using AutoMapper;
using MobilePhoneWebApp.BusinessLogic.Exceptions;
using SchoolSchedule.BusinessLogic.Dtos;
using SchoolSchedule.BusinessLogic.Requests;
using SchoolSchedule.BusinessLogic.Services.Interfaces;
using SchoolSchedule.DataAccess.Entities;
using SchoolSchedule.DataAccess.Repositories.Interfaces;

namespace SchoolSchedule.BusinessLogic.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentGroupRepository _studentGroupRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper, IStudentGroupRepository studentGroupRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _studentGroupRepository = studentGroupRepository;
        }

        public async Task<StudentDto> AddAsync(StudentRequest studentRequest)
        {
            var studentGroup = await _studentGroupRepository.GetByNameAsync(studentRequest.StudentGroupName);
            if (studentGroup == null)
            {
                throw new NotFoundException("Student group not found");
            }

            var studentEntity = _mapper.Map<Student>(studentRequest);
            studentEntity.StudentGroup = studentGroup;

            var addedStudent = await _studentRepository.AddAsync(studentEntity);

            return _mapper.Map<StudentDto>(addedStudent);
        }

        public async Task<StudentDto> DeleteAsync(int id)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(id);
            if (existingStudent is null)
            {
                throw new NotFoundException("Student not found");
            }

            var deletedStudent = await _studentRepository.DeleteAsync(existingStudent);

            return _mapper.Map<StudentDto>(deletedStudent);
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();

            return _mapper.Map<List<StudentDto>>(students);
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                throw new NotFoundException("Student not found");
            }

            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> UpdateAsync(int id, StudentRequest studentRequest)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(id);
            if (existingStudent is null)
            {
                throw new NotFoundException("Student not found");
            }

            var studentGroup = await _studentGroupRepository.GetByNameAsync(studentRequest.StudentGroupName);
            if (studentGroup == null)
            {
                throw new NotFoundException("Student group not found");
            }

            _mapper.Map(studentRequest, existingStudent);
            existingStudent.StudentGroup = studentGroup;
            var updatedStudent = await _studentRepository.UpdateAsync(existingStudent);

            return _mapper.Map<StudentDto>(updatedStudent);
        }
    }
}
