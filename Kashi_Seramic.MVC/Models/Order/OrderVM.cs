namespace Pr_Signal_ir.MVC.Models
{
    using global::Pr_Signal_ir.MVC.Models.OrderDetials;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Pr_Signal_ir.MVC.Models.Order
    {
        public class OrderVM: BaseDomainEntity
        {


            public string UserId { get; set; } = "8e445865-a24d-4543-a6c6-9443d048cdb9";
            public bool Finaly { get; set; }
            public ICollection<OrderDetialsVM> orderDetails { get; set; }

        }

        public class CreateOrderVM:BaseDomainEntity
        {
            public string UserId { get; set; } = "8e445865-a24d-4543-a6c6-9443d048cdb9";
            public bool Finaly { get; set; }
            public CreateOrderVM()
            {
  
            }

         
        }

        public class UpdateOrderVM:BaseDomainEntity
        {
            public string UserId { get; set; } = "8e445865-a24d-4543-a6c6-9443d048cdb9";
            public bool Finaly { get; set; }
        }

        public class AddUserToDore
        {
            public string UserId { get; set; }
            public int BlogId { get; set; }
            public IEnumerable<ProductVM> Blog { get; set; }
        }



    }

}
