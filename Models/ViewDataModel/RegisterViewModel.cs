using System.ComponentModel.DataAnnotations;

namespace Nextwo23.Models.ViewDataModel
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Required (ErrorMessage ="Enter User Email")]
        public string? Email { get; set; }
        [Required]
        [DataType (DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Not Match")]
        public string? ConfirmPassword { get; set; }
        public string? phone { get; set; } 
    }
}
