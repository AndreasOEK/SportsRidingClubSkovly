using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace SportsRidingClubSkovly.Web.ViewModels;

public class SignUpViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide username")]
    public string? Username { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide password")]
    public string? Password { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide first name")]
    public string? FirstName { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide last name")]
    public string? LastName { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide phone number")]
    public string? Phone { get; set; }
}