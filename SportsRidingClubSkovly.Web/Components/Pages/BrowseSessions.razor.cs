using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Module.User.Application.Features.UserManagement.Query.Dto;
using SportsRidingClubSkovly.Web.DTO.UserSession;
using SportsRidingClubSkovly.Web.DTO.TrainerSession;
using SportsRidingClubSkovly.Web.DTO.UserManagement;
using SportsRidingClubSkovly.Web.Services.Interface;
using SportsRidingClubSkovly.Web.ViewModels;

namespace SportsRidingClubSkovly.Web.Components.Pages;

[Authorize]
public partial class BrowseSessions
{
    private IEnumerable<SessionResponse> Sessions { get; set; } = [];
    private IEnumerable<TrainerResponse> Trainers { get; set; } = [];


    public CreateSessionViewModel ViewModel { get; set; } = new()
        { StartTime = DateTime.Now.AddDays(1), EndTimeOnly = TimeOnly.FromDateTime(DateTime.Now.AddHours(1)) };

    [Inject] public IUserSessionProxy UserSessionProxy { get; set; }
    [Inject] public IUserManagementProxy UserManagementProxy { get; set; }
    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Sessions = await UserSessionProxy.GetFutureSessionsAsync();
        var userRoleStr = (await GetUserClaimPrincipal()).FindFirst(ClaimTypes.Role)?.Value;

        switch (userRoleStr)
        {
            case "Admin":
                Trainers = await GetAllTrainersAsync();
                break;
            case "Trainer":
                var trainer = await GetTrainerAsync();
                ViewModel.TrainerFullName = trainer.FullName;
                ViewModel.AssignedTrainerId = trainer.Id;
                break;
        }
    }


    public int CalculateSlotsLeft(SessionResponse session)
        => session.MaxNumberOfParticipants - session.Bookings.Count();

    private async Task CreateSessionAsync()
    {
        var createSessionRequest = new CreateSessionRequest()
        {
            StartTime = ViewModel.StartTime,
            Duration = ViewModel.EndTimeOnly.ToTimeSpan() - (TimeOnly.FromDateTime(ViewModel.StartTime).ToTimeSpan()),
            AssignedTrainerId = ViewModel.AssignedTrainerId,
            MaxNumberOfParticipants = ViewModel.MaxNumberOfParticipants,
            DifficultyLevel = ViewModel.DifficultyLevel,
            Type = ViewModel.Type
        };

        var response = await UserSessionProxy.CreateSession(createSessionRequest);
        
        if (response)
            Sessions = await UserSessionProxy.GetFutureSessionsAsync();
    }

    private async Task<CreateSessionTrainerResponse> GetTrainerAsync()
    {
        var userIdStr = (await GetUserClaimPrincipal()).FindFirst(ClaimTypes.Sid)?.Value;
        var userId = Guid.Parse(userIdStr);
        var trainer = await UserManagementProxy.GetTrainerByUserId(new GetTrainerByUserIdRequest(userId));
        return trainer;
    }

    private async Task<ClaimsPrincipal> GetUserClaimPrincipal()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        return authState.User;
    }

    private async Task<IEnumerable<TrainerResponse>> GetAllTrainersAsync()
        => await UserManagementProxy.GetAllTrainers();
}