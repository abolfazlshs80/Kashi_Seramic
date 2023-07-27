namespace Pr_Signal_ir.MVC.Models.Users
{

    public class UpdateUserVM
    {
        public UpdateUserVM()
        {
            password = new PasswordUserVM();
        }
        public EmployeeVM User { get; set; }
        public PasswordUserVM password { get; set; }
        public string Error { get; set; }
    }
    public class PasswordUserVM
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

