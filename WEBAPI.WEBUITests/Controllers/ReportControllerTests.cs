using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WEBAPI.DAL;
using WEBAPI.DAL.Repository;
using WEBAPI.WEBUI.BL.Reports;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace WEBAPI.WEBUI.Controllers.Tests
{
    public class ReportControllerTests
    {
        [Fact]
        public void CreateReportTest()
        {
            // Arrange
            var mockILoggerReportController = new Mock<ILogger<ReportController>>();
            var mockILoggerEducationRepository = new Mock<ILogger<EducationRepository>>();
            var mockILoggerModuleContext = new Mock<ILogger<WEBAPIContext>>();
            var mockILoggerFD = new Mock<ILogger<FillDatabaseController>>();
            DbContextOptionsBuilder<WEBAPIContext> optionsBuilder = new DbContextOptionsBuilder<WEBAPIContext>();
            optionsBuilder.UseInMemoryDatabase("CreateReportTestDb");
            WEBAPIContext context = new WEBAPIContext(optionsBuilder.Options, mockILoggerModuleContext.Object);
            var educationRepository = new EducationRepository(context, mockILoggerEducationRepository.Object);
            var mockIReportSaver = new Mock<IReportSaver>();
            List<LineOfReport> linesOfReportExpect = new List<LineOfReport>();
            List<LineOfReport> linesOfReportAcnual = new List<LineOfReport>();
            mockIReportSaver.Setup(d => d.Type).Returns("xml");
            FillDatabaseController controllerFD = new FillDatabaseController(educationRepository, mockILoggerFD.Object);
            // Act
            controllerFD.FillDatabase();
            ReportController controller = new ReportController(educationRepository, mockILoggerReportController.Object, new List<IReportSaver> { mockIReportSaver.Object });
            controller.CreateReport("Ivan Ivanov", "student", "xml");
            // Assert
            mockIReportSaver.Verify(rs => rs.SendReport(It.Is<ICollection<LineOfReport>>(lr => lr.Count == 4)));
        }
        [Fact]
        public void CreateReportWichEmptyDBTest()
        {
            // Arrange
            var mockILoggerReportController = new Mock<ILogger<ReportController>>();
            var mockILoggerEducationRepository = new Mock<ILogger<EducationRepository>>();
            var mockILoggerModuleContext = new Mock<ILogger<WEBAPIContext>>();
            DbContextOptionsBuilder<WEBAPIContext> optionsBuilder = new DbContextOptionsBuilder<WEBAPIContext>();
            optionsBuilder.UseInMemoryDatabase("CreateReportCreateReportWichEmptyDBTestDb");
            WEBAPIContext context = new WEBAPIContext(optionsBuilder.Options, mockILoggerModuleContext.Object);
            var educationRepository = new EducationRepository(context, mockILoggerEducationRepository.Object);
            var mockIReportSaver = new Mock<IReportSaver>();
            List<LineOfReport> linesOfReportExpect = new List<LineOfReport>();
            List<LineOfReport> linesOfReportAcnual = new List<LineOfReport>();
            mockIReportSaver.Setup(d => d.Type).Returns("xml");
            ReportController controller = new ReportController(educationRepository, mockILoggerReportController.Object, new List<IReportSaver> { mockIReportSaver.Object });
            // Act
            educationRepository.EnsureDeleted();
            controller.CreateReport("Ivan Ivanov", "student", "xml");
            // Assert
            mockIReportSaver.Verify(rs => rs.SendReport(It.Is<ICollection<LineOfReport>>(lr => lr.Count == 0)));
        }

    }
}