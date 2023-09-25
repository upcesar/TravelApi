using FluentValidation.Results;
using TravelManagement.Api.Application.Commands;
using TravelManagement.Api.Requests;
using TravelManagement.Domain.Entities;
using TravelManagement.Infra.Data.Repositories;
using TravelManagement.Infra.Security.Cryptography;

namespace TravelManagement.Api.Services;

public interface IUserService
{
    Task<ValidationResult> Register(UserRequest request);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IEncryptService _encryptService;

    public UserService(IUserRepository userRepository, IEncryptService encryptService)
    {
        _userRepository = userRepository;
        _encryptService = encryptService;
    }

    public async Task<ValidationResult> Register(UserRequest request)
    {
        var command = new SignInCommand(request.Email, request.FullName, request.Password);

        if (command.IsValid)
        {
            var user = new User(command.Email, command.FullName, _encryptService.Encrypt(command.Password));
            await _userRepository.InsertAsync(user);
        }

        return command.ValidationResult;
    }
}
