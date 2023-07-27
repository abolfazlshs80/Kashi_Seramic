using Kashi_Seramic.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Persistences.Configurations.Entities
{
    public class TicketGroupConfiguration : IEntityTypeConfiguration<TicketGroup>
    {
        public void Configure(EntityTypeBuilder<TicketGroup> builder)
        {
            builder.HasKey(x => x.Id);
         

            //builder.HasMany(a => a.TicketGroupToBlog)
            //.WithOne(a => a.TicketGroup)
            //.HasForeignKey(a=>a.TicketGroupId);

        }
    }
}
