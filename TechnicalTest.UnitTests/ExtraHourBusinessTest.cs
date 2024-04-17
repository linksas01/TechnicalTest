using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechnicalTest.Business;
using TechnicalTest.Business.Interfaces;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interfaces;
using TechnicalTest.Utilities.Configs;
using TechnicalTest.Utilities.Exceptions;

namespace TechnicalTest.UnitTests
{
    public class ExtraHourBusinessTest
    {
        private Mock<IExtraHourRepository> _extraHourRepository;
        private Mock<IAppConfig> _config;
        private IExtraHourBusiness _extraHourBusiness;

        [SetUp]
        public void Setup()
        {
            _extraHourRepository = new Mock<IExtraHourRepository>();
            _config = new Mock<IAppConfig>();
            _extraHourBusiness = new ExtraHourBusiness(_config.Object, _extraHourRepository.Object);
        }

        [Test]
        [ExpectedException(typeof(BusinessException))]
        public void AddMaxHoursMonthException()
        {
            // Arange
            var employeeId = Guid.NewGuid();
            var actualDate = DateTime.UtcNow;
            var extraHour = new ExtraHour { Id = Guid.NewGuid(), Hours = 20, EmployeeId = employeeId };
            IEnumerable<ExtraHour> expectedExtraHours =
                [
                    new ExtraHour 
                    {
                        Id = Guid.NewGuid(),
                        Hours = 20,
                        EmployeeId = employeeId,
                        Date = new DateOnly(actualDate.Year, actualDate.Month, actualDate.Day)
                    },
                    new ExtraHour 
                    {
                        Id = Guid.NewGuid(),
                        Hours = 5,
                        EmployeeId = employeeId,
                        Date = new DateOnly(actualDate.Year, actualDate.Month, actualDate.Day)
                    }
                ];
            _extraHourRepository.Setup(it => it.Get()).Returns(Task.FromResult(expectedExtraHours));

            // Act
            _extraHourBusiness.Add(extraHour);
        }
    }
}