using System.ComponentModel.DataAnnotations;

namespace SportsRidingClubSkovly.Web.ViewModels;

public class ProfileViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Email")]
    public string? Email { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide first name")]
    public string? FirstName { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide last name")]
    public string? LastName { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide phone number")]
    public string? Phone { get; set; }
}