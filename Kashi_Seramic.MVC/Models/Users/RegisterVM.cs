﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pr_Signal_ir.MVC.Models
{
    public class RegisterVM
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [MinLength(6,ErrorMessage ="حداقل نعداد حروف باید 6 باشید")]
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}
