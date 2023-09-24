using FluentAssertions;
using TravelManagement.Domain.Common;
using TravelManagement.Domain.SmartEnums;
using Xunit;

namespace TravelManagement.UnitTest.DomainObjects;
public class DomainObjectsTests
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
}
