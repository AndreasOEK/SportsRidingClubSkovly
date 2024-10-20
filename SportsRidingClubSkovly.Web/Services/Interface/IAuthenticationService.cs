using SportsRidingClubSkovly.Web.ViewModels;

namespace SportsRidingClubSkovly.Web.Services.Interface;

public interface IAuthenticationService
{
    Task LoginAsync(LoginViewModel viewModel);
    Task SignUpAsync(SignUpViewModel viewModel);
    Task LogoutAsync();
    Task<string> GetJwtAsync();
}