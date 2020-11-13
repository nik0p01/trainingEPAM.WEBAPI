using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using WEBAPI.BL.Reports;
using WEBAPI.DAL;
using WEBAPI.DAL.Repository;
using WEBAPI.DAL.Entities;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace WEBAPI.WEBUI.Controllers.Tests
{
    public class WarningSenderControllerTests
    {
        [Fact]
        public void SendAllWarningsTest()
        {
            // Arrange
            var mockILoggerFillDatabaseController = new Mock<ILogger<WarningSenderController>>();
            var mockILoggerEducationRepository = new Mock<ILogger<EducationRepository>>();
            var mockILoggerModuleContext = new Mock<ILogger<WEBAPIContext>>();
            var mockILoggerSenderController = new Mock<ILogger<WarningSenderController>>();
            var mockILoggerGetDataForWarning = new Mock<ILogger<GetDataForWarning>>();
            var mockILoggerFD = new Mock<ILogger<FillDatabaseController>>();
            var mockILoggerISendWarning = new Mock<ILogger<ISendWarning>>();
            var mockISendWarning = new Mock<ISendWarning>();

            Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentBL>()));
            DbContextOptionsBuilder<WEBAPIContext> optionsBuilder = new DbContextOptionsBuilder<WEBAPIContext>();
            optionsBuilder.UseInMemoryDatabase("CreateReportSendAllWarningsTestDb");
            WEBAPIContext context = new WEBAPIContext(optionsBuilder.Options, mockILoggerModuleContext.Object);
            var educationRepository = new EducationRepository(context, mockILoggerEducationRepository.Object);
            GetDataForWarning getDataForWarning = new GetDataForWarning(educationRepository, mockILoggerGetDataForWarning.Object, mapper);
            WarningSenderController warningSenderController = new WarningSenderController(educationRepository, mockILoggerSenderController.Object, getDataForWarning, mockISendWarning.Object);
            FillDatabaseController controllerFD = new FillDatabaseController(educationRepository, mockILoggerFD.Object);
            // Act
            controllerFD.FillDatabase();
            warningSenderController.SendAllWarnings();

            // Assert
            mockISendWarning.Verify(sw => sw.SendWarningToStudents(It.Is<ICollection<StudentBL>>(s => s.Count == 3)));



        }
    }
}