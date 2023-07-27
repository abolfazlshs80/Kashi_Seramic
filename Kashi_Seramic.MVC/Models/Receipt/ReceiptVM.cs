using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

namespace Pr_Signal_ir.MVC.Models.Receipt
{
    public class ReceiptVM
    {
        public ProductVM  Blog { get; set; }
        public int Count { get; set; }
    }

    public class ReceiptUserVM
    {
        public EmployeeVM User { get; set; }

        public int Count { get; set; }
        public ProductVM Blog { get; set; }
    }
}
