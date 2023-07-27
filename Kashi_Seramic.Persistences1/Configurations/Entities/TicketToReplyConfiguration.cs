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
    public class TicketToReplyConfiguration : IEntityTypeConfiguration<TicketToReply>
    {
        public void Configure(EntityTypeBuilder<TicketToReply> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(a => a.Name).IsRequired().HasMaxLength(100);

            //builder.HasMany(a => a.TicketToReplyToBlog)
            //.WithOne(a => a.TicketToReply)
            //.HasForeignKey(a=>a.TicketToReplyId);

        }
    }
}
