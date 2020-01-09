using Xunit;
using FluentAssertions;
using WebApplicationHttpHeaders.Controllers;
using WebApplicationHttpHeaders.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace WebApplication.UnitTests
{
    public class PersonControllerTests
    {
        [Fact]
        public void GetPersonById_WithCorrectParameter_RetrunsStatusOK()
        {
            //AAA
            // tak wyglada "prawdziwy" test jednostkowy
            // bo testuje kontroller w izolacji (repo nie strzela do bazy)


            // zamiast samemu tworzyc bezsensowne protezty
            //var protezaRepo = new FakePersonRepository();

            // mozna uzyc MOQ, ale jak mamy INTERFEJS
            var proteza = new Mock<IPersonRepository>();
            proteza.Setup(r => r.GetAll()).Returns(new string[] { "fake", "data" });

            var personController = new PersonController(proteza.Object);

            var result = personController.GetPersonById(1);

            var ok = (OkObjectResult)result;
            var data = (string)ok.Value;

            // pierwsza przymiarka
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
            data.Should().Equals("fake");
            
        }
    }
}
