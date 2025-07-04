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
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>

    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.SaleId);

            builder.HasOne(s => s.Seller)
                .WithMany(u => u.Sales)
                .HasForeignKey(s => s.SellerId);
        }
    }
}
