using Bogus;
using FluentAssertions;
using TravelManagement.Api.Application.Commands;
using Xunit;

namespace TravelManagement.UnitTest.DomainObjects;

public class SignInCommandTest
{
    [Fact]
    public void User_AllFieldsFilled_ShouldBeValid()
    {
        // Arrange
        var complexPassword = "P4$$w0rd;H@rd";
        var user = new Faker<SignInCommand>()
                    .CustomInstantiator(fake => new SignInCommand(fake.Person.Email, fake.Person.FullName, complexPassword))
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
        SignInCommand signIn = new(string.Empty, string.Empty, string.Empty);

        // Act
        var result = signIn.IsValid;

        // Assert
        result.Should().BeFalse();
    }
}
