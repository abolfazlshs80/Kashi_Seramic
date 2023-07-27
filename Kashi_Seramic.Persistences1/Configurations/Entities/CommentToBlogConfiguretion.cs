using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kashi_Seramic.Domain;

namespace Pr_Signal_ir.Persistences.Configurations.Entities
{
    public class CommentToBlogConfiguretion : IEntityTypeConfiguration<CommentToBlog>
    {
        public void Configure(EntityTypeBuilder<CommentToBlog> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(a => a.Text).
                HasMaxLength(int.MaxValue)
                .IsRequired();
            builder.Property(a => a.FullName).
            HasMaxLength(50)
            .IsRequired();
            builder.Property(a => a.Email).
            HasMaxLength(100)
            .IsRequired();

            // builder.HasMany(a => a.CategoryToBlog)
            //     .WithOne(a => a.Blog)
            //     .HasForeignKey(a => a.BlogId);

            // builder.HasMany(a => a.FileToBlog)
            //.WithOne(a => a.Blog)
            //.HasForeignKey(a => a.BlogId);
        }
    }
}
