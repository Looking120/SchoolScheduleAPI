using AutoMapper;
using SchoolSchedule.BusinessLogic.Dtos;
using SchoolSchedule.BusinessLogic.Requests;
using SchoolSchedule.DataAccess.Entities;

namespace SchoolSchedule.API.Profiles
{
    public class StudentGroupProfile : Profile
    {
        public StudentGroupProfile()
        {
            //Mapping request for StudentGroup
            CreateMap<StudentGroupRequest, StudentGroup>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.GroupName));

            CreateMap<StudentGroup, StudentGroupDto>();

            //Maooing profile for Student
            CreateMap<StudentRequest, Student>()
                .ForMember(dest => dest.StudentGroup, opt =>
                    opt.MapFrom(src => new StudentGroup { GroupName = src.StudentGroupName }));

            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.StudentGroupName, opt =>
                    opt.MapFrom(src => src.StudentGroup.GroupName))
                .ForMember(dest => dest.StudentGroupId, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
