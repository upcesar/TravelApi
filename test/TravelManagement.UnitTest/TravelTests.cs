using FluentAssertions;
using TravelManagement.Domain.Common;
using TravelManagement.Domain.SmartEnums;
using TravelManagement.Infra.Services;
using Xunit;

namespace TravelManagement.UnitTest;

public class TravelTests
{
    [Fact]
    public void GetCountriesForecast_ShouldReturnList()
    {
        // Arrange
        var expectedCountriesCount = SmartEnumerator.AsEnumerable<Countries>().Count();
        var service = new TravelService();

        // Act
        var result = service.GetCountriesForecast();

        //Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(expectedCountriesCount);
    }
}
