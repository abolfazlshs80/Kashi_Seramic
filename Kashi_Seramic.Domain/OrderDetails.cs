
using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class OrderDetails : BaseDomainEntity
    {



        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }


        public Product Product { get; set; }
        public Orders Orders { get; set; }


    }
}
