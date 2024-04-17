using Moq;
using TechnicalTest.Business;
using TechnicalTest.Business.Interfaces;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interfaces;

namespace TechnicalTest.UnitTests
{
    public class AreaBusinessTest
    {        
        private Mock<IAreaRepository> _areaRepository;
        private IAreaBusiness _areaBusiness;        

        [SetUp]
        public void Setup()
        {
            _areaRepository = new Mock<IAreaRepository>();
            _areaBusiness = new AreaBusiness(_areaRepository.Object);
        }

        [Test]        
        public void GetAreasTest()
        {
            // Arange
            IEnumerable<Area> expectedAreas = [new Area { Id = 1 }, new Area { Id = 2 }];
            _areaRepository.Setup(it=> it.Get()).Returns(Task.FromResult(expectedAreas));

            // Act
            IEnumerable<Area> actualAreas = _areaBusiness.Get().Result;

            // Assert
            Assert.IsTrue(actualAreas.Any()); ;
        }

        [Test]
        public void NoGetAreasTest()
        {
            // Arange
            IEnumerable<Area> expectedAreas = Array.Empty<Area>();
            _areaRepository.Setup(it => it.Get()).Returns(Task.FromResult(expectedAreas));

            // Act
            IEnumerable<Area> actualAreas = _areaBusiness.Get().Result;

            // Assert
            Assert.IsFalse(actualAreas.Any()); ;
        }
    }
}