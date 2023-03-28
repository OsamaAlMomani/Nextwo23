namespace Nextwo23.Models.ViewDataModel.Roles
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel() {
            User = new List<string>();
        }
        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
        public List<string>? User;
    }
}
