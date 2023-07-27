
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Pr_Signal_ir.MVC.Models.OrderDetials
    {
        public class OrderDetialsVM: BaseDomainEntity
        {


        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }

        public ProductVM Product { get; set; }

        }

        public class CreateOrderDetialsVM:BaseDomainEntity
        {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }
    }


        public class UpdateOrderDetialsVM:BaseDomainEntity
        {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }
    }



    }


