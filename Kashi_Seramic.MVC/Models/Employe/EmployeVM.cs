namespace Pr_Signal_ir.MVC.Models.Employe
{
    public class EmployeVM
    {
        public string Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
    public class CreateEmployeVM
    {
        public string Id { get; set; }
        [Remote("IS_EMAIL_USE", "RemoteValidation", HttpMethod = "Post", AdditionalFields = "__RequestVerificationToken")]

        public string? Email { get; set; }
        [Remote("IS_USERNAME_USE", "RemoteValidation", HttpMethod = "Post", AdditionalFields = "__RequestVerificationToken")]
        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }

    public class EmployeResponseVM
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
    }
}
