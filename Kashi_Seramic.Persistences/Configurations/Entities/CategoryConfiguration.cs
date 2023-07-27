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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(a => a.CategoryToProduct)
            .WithOne(a => a.Category)
            .HasForeignKey(a=>a.CategoryId);

            builder.HasMany(a => a.FilterProduct)
           .WithOne(a => a.Categories)
           .HasForeignKey(a => a.CategoryId);

            builder.HasMany(a => a.CategoryToBlog)
           .WithOne(a => a.Category)
           .HasForeignKey(a => a.CategoryId);

        }
    }
}
