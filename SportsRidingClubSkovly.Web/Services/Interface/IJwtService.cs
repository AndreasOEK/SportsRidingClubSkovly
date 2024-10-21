namespace SportsRidingClubSkovly.Web.Services.Interface;

public interface IJwtService
{
    Guid GetUserId(string token);
    string GetUserName(string token);
    string GetUserEmail(string token);

}