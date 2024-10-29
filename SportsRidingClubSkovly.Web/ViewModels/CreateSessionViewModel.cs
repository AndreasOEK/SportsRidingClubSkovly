using System.ComponentModel.DataAnnotations;
using SportsRidingClubSkovly.Web.Abstractions.Enums;

namespace SportsRidingClubSkovly.Web.ViewModels;

public class CreateSessionViewModel
{
    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public TimeOnly EndTimeOnly { get; set; }
    [Required]
    public Guid AssignedTrainerId { get; set; }

    public string TrainerFullName { get; set; } = string.Empty;
    [Required]
    [Range(1, 10, ErrorMessage = "Please enter a number between 1 and 10")]
    public int MaxNumberOfParticipants { get; set; }
    [Required]
    public SkillLevel DifficultyLevel { get; set; }
    [Required]
    public SessionType Type { get; set; }
}