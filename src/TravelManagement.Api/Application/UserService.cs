using FluentValidation.Results;
using TravelManagement.Api.Application.Commands;
using TravelManagement.Api.Requests;
using TravelManagement.Domain.Entities;
using TravelManagement.Infra.Data.Repositories;

namespace TravelManagement.Api.Services;

public interface IUserService
{
    Task<ValidationResult> SignIn(UserRequest request);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ValidationResult> SignIn(UserRequest request)
    {
        var command = new SignInCommand(request.Email, request.FullName, request.Password);

        if (command.IsValid)
        {
            var user = new User(command.Email, command.FullName, command.Password);
            await _userRepository.InsertAsync(user);
        }

        return command.ValidationResult;
    }
}
