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
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);
      

            builder.HasOne(a => a.ticketGroup)
            .WithMany(a => a.SuportTicket)
            .HasForeignKey(a=>a.GroupId);

            builder.HasMany(a => a.TicketToReply)
            .WithOne(a => a.Ticket)
            .HasForeignKey(a => a.TicketId);
        }
    }
}
