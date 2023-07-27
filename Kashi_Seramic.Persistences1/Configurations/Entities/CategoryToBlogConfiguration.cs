﻿using Kashi_Seramic.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Persistences.Configurations.Entities
{
    public class CategoryToBlogConfiguration: IEntityTypeConfiguration<CategoryToBlog>
    {
        public void Configure(EntityTypeBuilder<CategoryToBlog> builder)
        {
            builder.HasKey(x => new {x.CategoryId,x.BlogId});
        }
    }
}
