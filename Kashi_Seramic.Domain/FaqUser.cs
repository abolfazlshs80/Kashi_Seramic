
using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Kashi_Seramic.Domain
{
    public class FaqUser : BaseDomainEntity
    {


        public string Text { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string ReplayText { get; set; }

    }
}
