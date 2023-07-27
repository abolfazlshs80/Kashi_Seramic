namespace Pr_Signal_ir.MVC.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Pr_Signal_ir.MVC.Models.FaqUser
    {
        public class FaqUserVM:BaseDomainEntity
        {

            public bool Status { get; set; }
            public string Text { get; set; }

            public string FullName { get; set; }

            public string Email { get; set; }

            public string ReplayText { get; set; }


        }

        public class CreateFaqUserVM:BaseDomainEntity
        {
            public bool Status { get; set; }
            public string Text { get; set; }

            public string FullName { get; set; }

            public string Email { get; set; }

            public string ReplayText { get; set; }

        }
        public class UpdateFaqUserVM:BaseDomainEntity
        {
            public bool Status { get; set; }
            public string Text { get; set; }

            public string FullName { get; set; }

            public string Email { get; set; }

            public string ReplayText { get; set; }
        }

        public class AdminFaqUserVMViewVM:BaseDomainEntity
        {
            public bool Status { get; set; }
            public string Text { get; set; }

            public string FullName { get; set; }

            public string Email { get; set; }

            public string ReplayText { get; set; }
        }


    }

}
