namespace Pr_Signal_ir.MVC.Models.Roles
{
    public class RoleVM
    {
        public string RoleId { get; set; }
        public string UserId { get; set; }
        public string RoleName { get; set; }
        public bool Selected { get; set; } = false;
    }
    public class UserRolesVM
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public class AddRoleVM
    {
        public string? RoleId { get; set; }
        public string RoleName { get; set; }

    }
    public class AddRoleToUserVM
    {
        public IEnumerable<RoleVM> Roles { get; set; }
        public List< string>  MyRoles { get; set; }
        public string UserId { get; set; }
    }
}
