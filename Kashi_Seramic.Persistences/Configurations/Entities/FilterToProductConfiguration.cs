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
    public class FilterToProductConfiguration : IEntityTypeConfiguration<FilterToProduct>
    {
        public void Configure(EntityTypeBuilder<FilterToProduct> builder)
        {
            builder.HasKey(x => new {x.FilterId,x.ProductId});
     

         


        }
    }

}



