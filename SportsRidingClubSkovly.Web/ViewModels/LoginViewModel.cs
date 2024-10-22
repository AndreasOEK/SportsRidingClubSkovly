using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace SportsRidingClubSkovly.Web.ViewModels;

public class LoginViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide username")]
    public string? Username { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide password")]
    public string? Password { get; set; }
}