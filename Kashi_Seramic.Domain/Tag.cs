
using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class Tag : BaseDomainEntity
    {


        public string Name { get; set; }

        public IEnumerable<TagToBlog> TagToBlog { get; set; }
        public IEnumerable<TagToProduct> TagToProduct { get; set; }
    }
}
