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
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(a => a.TagToBlog)
            .WithOne(a => a.Tag)
            .HasForeignKey(a=>a.TageId);


            builder.HasMany(a => a.TagToProduct)
            .WithOne(a => a.Tag)
            .HasForeignKey(a => a.TagId);

        }
    }
}
