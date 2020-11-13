using Microsoft.Extensions.Logging;
using WEBAPI.DAL.Repository;
using WEBAPI.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WEBAPI.BL
{
    public class FillDatabase
    {
        IEducationRepository _educationRepository;
        private ILogger _logger;


        public FillDatabase(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public FillDatabase(IEducationRepository educationRepository, ILogger logger) : this(educationRepository)
        {
            _logger = logger;
        }

        public void FillDatabaseTestData()
        {
            _educationRepository.EnsureDeleted();
            _educationRepository.EnsureCreated();
            List<Student> students = new List<Student>() {
                new Student() { FullName = "Ivan Ivanov", EMail="Foo@Bar.baz", Phone = "123456"  },
                new Student() { FullName = "Nikolai Ivanov", EMail="Nikolai@Bar.baz", Phone = "123456"  },
                new Student() { FullName = "Serdei Ivanov", EMail="Serdei@Bar.baz", Phone = "123456"  },
                new Student() { FullName = "Petr Ivanov", EMail="Petr@Bar.baz", Phone = "123456"   }
            };
            IStudentRepository studentRepository = _educationRepository.GetStudentRepository();
            students.ForEach(s => studentRepository.InsertStudent(s));
            studentRepository.Save();
            List<Lecturer> lecturers = new List<Lecturer>() { new Lecturer() { FullName = "Sergei Petrov" }, new Lecturer() { FullName = "Nick Petrov" } };
            ILecturerRepository lecturerRepository = _educationRepository.GetLecturerRepository();
            lecturers.ForEach(l => lecturerRepository.InsertLecturer(l));
            lecturerRepository.Save();
            List<Lecture> lectures = new List<Lecture> {
                new Lecture() { Title = "Jamping", Lecturer = lecturerRepository.GetLecturers().First() },
                new Lecture() { Title = "Riding", Lecturer = lecturerRepository.GetLecturers().First() },
                new Lecture() { Title = "Joging", Lecturer = lecturerRepository.GetLecturers().First() },
                new Lecture() { Title = "Climbing", Lecturer = lecturerRepository.GetLecturers().Last() }
            };
            ILectureRepository lectureRepository = _educationRepository.GetLectureRepository();
            lectures.ForEach(l => lectureRepository.InsertLecture(l));
            lectureRepository.Save();
            List<AttendingLecture> attendingLectures = new List<AttendingLecture> {
                new AttendingLecture() { Atended = false, Lecture = lectureRepository.GetLectures().ToList()[0], Student = studentRepository.GetStudents().ToList()[0] },
                new AttendingLecture() { Atended = false, Lecture = lectureRepository.GetLectures().ToList()[1], Student = studentRepository.GetStudents().ToList()[0]},
                new AttendingLecture() { Atended = false, Lecture = lectureRepository.GetLectures().ToList()[2], Student = studentRepository.GetStudents().ToList()[0]},
                new AttendingLecture() { Atended = false, Lecture = lectureRepository.GetLectures().ToList()[3], Student = studentRepository.GetStudents().ToList()[0]},

                new AttendingLecture() { Atended = true, Lecture = lectureRepository.GetLectures().ToList()[0], Student = studentRepository.GetStudents().ToList()[1] },
                new AttendingLecture() { Atended = true, Lecture = lectureRepository.GetLectures().ToList()[1], Student = studentRepository.GetStudents().ToList()[1]},
                new AttendingLecture() { Atended = true, Lecture = lectureRepository.GetLectures().ToList()[2], Student = studentRepository.GetStudents().ToList()[1]},
                new AttendingLecture() { Atended = false, Lecture = lectureRepository.GetLectures().ToList()[3], Student = studentRepository.GetStudents().ToList()[1]},

                new AttendingLecture() { Atended = false, Lecture = lectureRepository.GetLectures().Last(), Student = studentRepository.GetStudents().Last() }
            };
            IAttendingLectureRepository attendingLectureRepository = _educationRepository.GetAttendingLectureRepository();
            attendingLectures.ForEach(a => attendingLectureRepository.InsertAttendingLecture(a));
            attendingLectureRepository.Save();
            attendingLectures = attendingLectureRepository.GetAttendingLectures().ToList();
            List<HomeWork> homeWorks = new List<HomeWork> {
                new HomeWork() { AttendingLecture = attendingLectures[0], CourseGrade = 0 },
                new HomeWork() { AttendingLecture = attendingLectures[1], CourseGrade = 1 },
                new HomeWork() { AttendingLecture = attendingLectures[2], CourseGrade = 2 },
                new HomeWork() { AttendingLecture = attendingLectures[3], CourseGrade = 3 },
                new HomeWork() { AttendingLecture = attendingLectures[4], CourseGrade = 4 } ,
                new HomeWork() { AttendingLecture = attendingLectures[5], CourseGrade =4 },
                new HomeWork() { AttendingLecture = attendingLectures[6], CourseGrade = 4 },
                new HomeWork() { AttendingLecture = attendingLectures[7], CourseGrade = 4 },
                new HomeWork() { AttendingLecture = attendingLectures[8], CourseGrade = 1},
            };



            IHomeWorkRepository homeWorkRepository = _educationRepository.GetHomeWorkRepository();
            homeWorks.ForEach(h => homeWorkRepository.InsertHomeWork(h));
            homeWorkRepository.Save();
        }
    }
}
