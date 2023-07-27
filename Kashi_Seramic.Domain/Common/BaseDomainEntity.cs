using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Domain.Common
{
    public abstract class BaseDomainEntity
    {

        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public string? Owner { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool Status { get; set; } = true;
    }
}
