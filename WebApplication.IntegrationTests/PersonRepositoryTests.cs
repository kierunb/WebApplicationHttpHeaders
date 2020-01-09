using System;
using WebApplicationHttpHeaders.Repositories;
using Xunit;
using FluentAssertions;

namespace WebApplication.IntegrationTests
{
    public class PersonRepositoryTests
    {
        // Smoke/BVT tests
        
        [Fact]
        public void GetAllMethod_Should_ReturnAllEPersons()
        {

            var repository = new PersonRepository();

            repository.GetAll().Should().HaveCountGreaterOrEqualTo(2);
        }
    }
}
