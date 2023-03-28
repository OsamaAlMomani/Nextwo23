using System.ComponentModel.DataAnnotations;

namespace Nextwo23.Models.ViewDataModel
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Enter User Email")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
