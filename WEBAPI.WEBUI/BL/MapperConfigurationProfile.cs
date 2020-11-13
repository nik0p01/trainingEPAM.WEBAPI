using AutoMapper;
using WEBAPI.BL.Entities;
using WEBAPI.DAL.Entities;


namespace WEBAPI.WEBUI.BL
{
    public class MapperConfigurationProfile : Profile
    {
        public MapperConfigurationProfile()
        {
            CreateMap<Student, StudentBL>();
            CreateMap<Lecturer, LecturerBL>();
            CreateMap<Lecture, LectureBL>();
            CreateMap<AttendingLecture, AttendingLectureBL>();
            CreateMap<HomeWork, HomeWorkBL>();

            CreateMap<StudentBL, Student>();
            CreateMap<LecturerBL, Lecturer>();
            CreateMap<LectureBL, Lecture>();
            CreateMap<AttendingLectureBL, AttendingLecture>();
            CreateMap<HomeWorkBL, HomeWork>();
        }
    }
}
