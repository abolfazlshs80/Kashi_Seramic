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
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.Property(a => a.TitleBrowser).HasMaxLength(50);
            //builder.Property(a => a.Tag).HasMaxLength(500);
            //builder.Property(a => a.ShortName).HasMaxLength(50);
            //builder.Property(a => a.LognName).HasMaxLength(100);
            builder.HasMany(a => a.CategoryToBlog)
            .WithOne(a => a.Blog)
            .HasForeignKey(a => a.BlogId);

            builder.HasMany(a => a.FileToBlog)
           .WithOne(a => a.Blog)
           .HasForeignKey(a => a.BlogId);


            builder.HasMany(a => a.CommentToBlog)
           .WithOne(a => a.Blog)
           .HasForeignKey(a => a.BlogId);

            builder.HasMany(a => a.CategoryToBlog)
           .WithOne(a => a.Blog)
           .HasForeignKey(a => a.BlogId);


            builder.HasMany(a => a.TagToBlog)
           .WithOne(a => a.Blog)
           .HasForeignKey(a => a.BlogId);
        }
    }

}
