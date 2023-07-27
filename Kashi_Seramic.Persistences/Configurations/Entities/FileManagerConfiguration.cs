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
    public class FileManagerConfiguration : IEntityTypeConfiguration<FileManager>
    {
        public void Configure(EntityTypeBuilder<FileManager> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Path).IsRequired();

            builder.HasMany(a => a.FileToBlog)
              .WithOne(a => a.FileManager)
              .HasForeignKey(a=>a.ImageId);

            builder.HasMany(a => a.FileToProduct)
              .WithOne(a => a.FileManager)
              .HasForeignKey(a => a.ImageId);
     
        }
    }

}



