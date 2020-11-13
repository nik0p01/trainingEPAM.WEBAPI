using AutoMapper;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using WEBAPI.DAL.Repository;
using WEBAPI.DAL.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WEBAPI.BL.Reports.Tests
{
    public class GetDataForWarningTests
    {
        [Fact]
        public void AverageMarkLimitTest()
        {
            // Arrange
            var mockIEducationRepository = new Mock<IEducationRepository>();
            var mockIStudentRepository = new Mock<IStudentRepository>();
            mockIEducationRepository.Setup(er => er.GetStudentRepository()).Returns(mockIStudentRepository.Object);
            var mockILoggerStudentsService = new Mock<ILogger<GetDataForWarning>>();
            HomeWork homeWork = new HomeWork() { CourseGrade = 2 };
            HomeWork homeWork2 = new HomeWork() { CourseGrade = 4 };
            AttendingLecture al1 = new AttendingLecture() { Atended = false };
            AttendingLecture al2 = new AttendingLecture() { Atended = true, HomeWork = homeWork };
            AttendingLecture al3 = new AttendingLecture() { Atended = true, HomeWork = homeWork2 };
            Student st1 = new Student() { FullName = "s1", AttendingLectures = new HashSet<AttendingLecture>() { al1 } };
            Student st2 = new Student() { FullName = "s2", AttendingLectures = new HashSet<AttendingLecture>() { al2 } };
            Student st3 = new Student() { FullName = "s3", AttendingLectures = new HashSet<AttendingLecture>() { al3 } };
            Student st4 = new Student() { FullName = "s4" };
            mockIStudentRepository.Setup(sr => sr.GetStudentsIncludeAttendingLecturesAndHomeWork()).Returns(new List<Student>() { st1, st2, st3, st4, });
            Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentBL>()));
            GetDataForWarning getDataForWarning = new GetDataForWarning(mockIEducationRepository.Object, mockILoggerStudentsService.Object, mapper);
            List<string> expected = new List<string>() { "s1", "s2" };

            //act
            List<string> actual = getDataForWarning.AverageMarkLimit(4).ToList().ConvertAll(s => s.FullName);

            //assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void GetStudentsPassesTest()
        {
            // Arrange
            var mockIEducationRepository = new Mock<IEducationRepository>();
            var mockIStudentRepository = new Mock<IStudentRepository>();
            mockIEducationRepository.Setup(er => er.GetStudentRepository()).Returns(mockIStudentRepository.Object);
            var mockILoggerStudentsService = new Mock<ILogger<GetDataForWarning>>();
            AttendingLecture al1 = new AttendingLecture() { Atended = false };
            AttendingLecture al12 = new AttendingLecture() { Atended = false };
            AttendingLecture al13 = new AttendingLecture() { Atended = false };
            AttendingLecture al2 = new AttendingLecture() { Atended = true, };
            AttendingLecture al3 = new AttendingLecture() { Atended = true, };
            Student st1 = new Student() { FullName = "s1", AttendingLectures = new HashSet<AttendingLecture>() { al1, al12, al13 } };
            Student st2 = new Student() { FullName = "s2", AttendingLectures = new HashSet<AttendingLecture>() { al2 } };
            Student st3 = new Student() { FullName = "s3", AttendingLectures = new HashSet<AttendingLecture>() { al3 } };
            Student st4 = new Student() { FullName = "s4" };
            mockIStudentRepository.Setup(sr => sr.GetStudentsIncludeAttendingLecturesAndHomeWork()).Returns(new List<Student>() { st1, st2, st3, st4, });
            Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentBL>()));
            GetDataForWarning getDataForWarning = new GetDataForWarning(mockIEducationRepository.Object, mockILoggerStudentsService.Object, mapper);
            List<string> expected = new List<string>() { "s1" };

            //act
            List<string> actual = getDataForWarning.GetStudentsPasses(3).ToList().ConvertAll(s => s.FullName);

            //assert
            Assert.Equal(expected, actual);
        }
    }
}