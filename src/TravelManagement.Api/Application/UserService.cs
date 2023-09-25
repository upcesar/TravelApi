using FluentValidation.Results;
using TravelManagement.Api.Application.Commands;
using TravelManagement.Api.Requests;
using TravelManagement.Api.Responses;
using TravelManagement.Domain.Entities;
using TravelManagement.Infra.Data.Repositories;
using TravelManagement.Infra.Security.Auth;
using TravelManagement.Infra.Security.Cryptography;

namespace TravelManagement.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IEncryptService _encryptService;
    private readonly IJwtUtils _jwtUtils;

    public UserService(IUserRepository userRepository, IEncryptService encryptService, IJwtUtils jwtUtils)
    {
        _userRepository = userRepository;
        _encryptService = encryptService;
        _jwtUtils = jwtUtils;
    }

    public async Task<AuthenticateResponse> Authenticate(LoginRequest request)
    {
        var encryptedPassword = _encryptService.Encrypt(request.Password);
        var user = await _userRepository.GetByEmailAndPasswordAsync(request.Email, encryptedPassword);

        if (user is null)
        {
            return null;
        }

        var token = _jwtUtils.GenerateJwtToken(user);

        return new AuthenticateResponse(user, token);
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
