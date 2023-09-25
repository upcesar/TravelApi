using FluentValidation.Results;
using TravelManagement.Api.Requests;
using TravelManagement.Api.Responses;

namespace TravelManagement.Api.Services;

public interface IUserService
{
    Task<ValidationResult> Register(UserRequest request);
    Task<AuthenticateResponse> Authenticate(LoginRequest request);
}
