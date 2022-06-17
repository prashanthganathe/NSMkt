using NSMktAPI.Requests;
using NSMktAPI.Responses;

namespace NSMktAPI.Interfaces
{
    public interface IUserService
    {
        Task<TokenResponse> LoginAsync(LoginRequest loginRequest);
        Task<SignupResponse> SignupAsync(SignupRequest signupRequest);

        Task<LogoutResponse> LogoutAsync(int userId);
        Task<UserResponse> GetInfoAsync(int userId);
    }
}
