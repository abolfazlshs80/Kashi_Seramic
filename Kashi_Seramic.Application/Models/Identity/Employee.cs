using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Models.Identity
{
    public class Employee
    {
        public string Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
