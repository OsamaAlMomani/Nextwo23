using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Nextwo23.Models.ViewDataModel.Roles
{
    public class CreateRoleViewModel
    {
        [Required]
        public string? RoleName { get; set; }   
    }
}
