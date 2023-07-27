using System;
using System.Collections.Generic;
using System.Text;

namespace Pr_Signal_ir.Application.DTOs.Common
{
    public abstract class BaseDto
    {
        public string? Owner { get; set; }
        public int Id { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool Status { get; set; } = true;
    }
}
