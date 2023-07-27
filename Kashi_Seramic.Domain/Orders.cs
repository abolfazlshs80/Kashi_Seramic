
using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class Orders : BaseDomainEntity
    {



        public string UserId { get; set; }

        public DateTime Createdate { get; set; }
        public bool Finaly { get; set; }


        public ICollection<OrderSatus> orderSatus { get; set; }
        public ICollection<OrderDetails> orderDetails { get; set; }


    }
}
