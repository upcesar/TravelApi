using Bogus;
using FluentAssertions;
using TravelManagement.Domain.Entities;
using Xunit;

namespace TravelManagement.UnitTest.DomainObjects;

public class UserEntityTest
{
    [Fact]
    public void User_AllFieldsFilled_ShouldBeValid()
    {
        // Arrange
        var complexPassword = "P4$$w0rd;H@rd";
        var user = new Faker<Users>()
            .CustomInstantiator(fake => new Users(fake.Person.Email, fake.Person.FullName, complexPassword))
            .Generate();

        // Act
        var result = user.IsValid;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void User_FieldsEmpty_ShouldNotBeValid()
    {
        // Arrange
        var user = new Users(string.Empty, string.Empty, string.Empty);

        // Act
        var result = user.IsValid;

        // Assert
        result.Should().BeFalse();
    }
}
