using Kashi_Seramic.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Persistences.Configurations.Entities
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(a => a.CategoryToProduct)
                .WithOne(a => a.Product)
                .HasForeignKey(a => a.ProductId);

            builder.HasMany(a => a.FileToProduct)
           .WithOne(a => a.Product)
           .HasForeignKey(a => a.ProductId);
            builder.HasMany(a => a.TagToProduct)
    .WithOne(a => a.Product)
    .HasForeignKey(a => a.ProductId);

            builder.HasMany(a => a.CommentToProduct)
       .WithOne(a => a.Product)
       .HasForeignKey(a => a.ProductId);


        }
    }
}
