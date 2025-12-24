using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.DataLayer.Config
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.HasKey(s => s.SaleItemId);

            builder.HasOne(x => x.sale)
               .WithMany(x => x.saleItem)
               .HasForeignKey(x => x.SaleId);

            builder.HasOne(x => x.product)
               .WithMany(x => x.saleItem)
               .HasForeignKey(x => x.ProductId);
        }
    }
}
