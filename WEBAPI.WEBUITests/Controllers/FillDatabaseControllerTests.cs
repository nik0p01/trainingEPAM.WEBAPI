using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WEBAPI.DAL;
using WEBAPI.DAL.Repository;
using WEBAPI.DAL.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace WEBAPI.WEBUI.Controllers.Tests
{
    public class FillDatabaseControllerTests
    {
        [Fact]
        public void FillDatabaseTest()
        {
            // Arrange
            var mockILoggerFillDatabaseController = new Mock<ILogger<FillDatabaseController>>();
            var mockILoggerEducationRepository = new Mock<ILogger<EducationRepository>>();
            var mockILoggerModuleContext = new Mock<ILogger<WEBAPIContext>>();
            DbContextOptionsBuilder<WEBAPIContext> optionsBuilder = new DbContextOptionsBuilder<WEBAPIContext>();
            optionsBuilder.UseInMemoryDatabase("FillDatabaseTestDb");
            WEBAPIContext context = new WEBAPIContext(optionsBuilder.Options, mockILoggerModuleContext.Object);
            var educationRepository = new EducationRepository(context, mockILoggerEducationRepository.Object);
            FillDatabaseController controller = new FillDatabaseController(educationRepository, mockILoggerFillDatabaseController.Object);
            List<Student> studentsExp = new List<Student>() {
                new Student() { FullName = "Ivan Ivanov", EMail="Foo@Bar.baz", Phone = "123456"  },
                new Student() { FullName = "Nikolai Ivanov", EMail="Nikolai@Bar.baz", Phone = "123456"  },
                new Student() { FullName = "Serdei Ivanov", EMail="Serdei@Bar.baz", Phone = "123456"  },
                new Student() { FullName = "Petr Ivanov", EMail="Petr@Bar.baz", Phone = "123456"   }
            };

            // Act
            controller.FillDatabase();
            var studentsActual = context.Students.ToList();

            // Assert
            Assert.Equal(studentsExp.Count, studentsActual.Count);
            foreach (var studentActual in studentsActual)
            {
                var studentExpect = studentsExp.Find(s => s.FullName == studentActual.FullName);
                Assert.NotNull(studentExpect);
                Assert.Equal(studentExpect.EMail, studentActual.EMail);
                Assert.Equal(studentExpect.Phone, studentActual.Phone);
            }
        }
    }
}