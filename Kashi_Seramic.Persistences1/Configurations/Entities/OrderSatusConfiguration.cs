﻿using Kashi_Seramic.Domain;
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
    public class OrderSatusConfiguration : IEntityTypeConfiguration<OrderSatus>
    {
        public void Configure(EntityTypeBuilder<OrderSatus> builder)
        {
            builder.HasKey(x => x.Id);


        }
    }
}
