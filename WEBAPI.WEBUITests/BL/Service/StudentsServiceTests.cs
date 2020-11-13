using AutoMapper;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using WEBAPI.DAL.Repository;
using WEBAPI.DAL.Entities;
using WEBAPI.WEBUI.BL.Exceptions;
using Moq;
using Xunit;

namespace WEBAPI.WEBUI.BL.Service.Tests
{
    public class StudentsServiceTests
    {
        Mock<ILogger<StudentsService>> _mockILoggerStudentsService;
        Mock<IEducationRepository> _mockIEducationRepository;
        Mock<IStudentRepository> _mockIStudentRepository;
        Mapper _mapper;
        StudentsService _studentsService;
        StudentBL _studentBL;

        public StudentsServiceTests()
        {
            _mockILoggerStudentsService = new Mock<ILogger<StudentsService>>();
            _mockIEducationRepository = new Mock<IEducationRepository>();
            _mockIStudentRepository = new Mock<IStudentRepository>();
            _mockIEducationRepository.Setup(er => er.GetStudentRepository()).Returns(_mockIStudentRepository.Object);
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<StudentBL, Student>()));
            _studentsService = new StudentsService(_mockIEducationRepository.Object, _mockILoggerStudentsService.Object, _mapper);
            _studentBL = new StudentBL() { EMail = "q@q.q", FullName = "Ivan", Phone = "12345678" };
        }


        [Fact()]
        public void InsertStudentTest()
        {
            // Arrange


            // Act
            _studentsService.InsertStudent(_studentBL);


            // Assert
            _mockIStudentRepository.Verify(rs => rs.InsertStudent(It.Is<Student>(st => st.EMail == "q@q.q" && st.FullName == "Ivan" && st.Phone == "12345678")));
        }

        [Fact()]
        public void GetStudentsTest()
        {
            // Act
            _studentsService.GetStudents();

            // Assert
            _mockIStudentRepository.Verify(rs => rs.GetStudents());
        }

        [Fact()]
        public void GetStudentByIDTest()
        {

            // Act
            _studentsService.GetStudentByID(42);

            // Assert
            _mockIStudentRepository.Verify(rs => rs.GetStudentByID(It.Is<int>(i => i == 42)));
        }

        [Fact()]
        public void GetStudentByIDWichNegativIDTest()
        {

            // Act
            // Assert
            Assert.Throws<NegativeIDException>(() => _studentsService.GetStudentByID(-42));
        }


        [Fact()]
        public void DeleteStudentTest()
        {
            // Act
            _studentsService.DeleteStudent(42);

            // Assert
            _mockIStudentRepository.Verify(rs => rs.DeleteStudent(It.Is<int>(i => i == 42)));
        }

        [Fact]
        public void UpdateStudentTest()
        {
            // Act
            _studentsService.UpdateStudent(_studentBL);

            // Assert
            _mockIStudentRepository.Verify(rs => rs.UpdateStudent(It.Is<Student>(st => st.EMail == "q@q.q" && st.FullName == "Ivan" && st.Phone == "12345678")));
        }
    }
}