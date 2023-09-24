using Bogus;
using FluentAssertions;
using TravelManagement.Domain.Common;
using TravelManagement.Domain.SmartEnums;
using Xunit;

namespace TravelManagement.UnitTest.DomainObjects;

public class SmartEnumTests
{
    [Fact]
    public void SmartEnum_GetById_ShouldReturnEnum()
    {
        // Arrange
        var countryId = 1;

        // Act
        var result = SmartEnumerator.Get<Countries>(countryId);

        // Assert
        result.Should().Be(Countries.USA);
    }

    [Fact]
    public void SmartEnum_GetByName_ShouldReturnEnum()
    {
        // Arrange
        var countryName = "Brazil";

        // Act
        var result = SmartEnumerator.Get<Countries>(countryName);

        // Assert
        result.Should().Be(Countries.Brazil);
    }

    [Fact]
    public void SmartEnum_GetByInvalidId_ShouldReturnNull()
    {
        // Arrange
        var invalidCountryId = new Faker().Random.Number(100, 1000);

        // Act
        var result = SmartEnumerator.Get<Countries>(invalidCountryId);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void SmartEnum_GetByRandomName_ShouldReturnNull()
    {
        // Arrange
        var invalidCountryName = new Faker().Random.Word();

        // Act
        var result = SmartEnumerator.Get<Countries>(invalidCountryName);

        // Assert
        result.Should().BeNull();
    }
}
