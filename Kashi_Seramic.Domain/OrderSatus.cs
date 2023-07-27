
using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class OrderSatus : BaseDomainEntity
    {


        public int OrderId { get; set; }

        public Orders Orders { get; set; }
    }
}
