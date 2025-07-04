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
    public class InventoryLogConfiguration : IEntityTypeConfiguration<InventoryLog>

    {
        public void Configure(EntityTypeBuilder<InventoryLog> builder)
        {
            builder.HasKey(i => i.LogId);

            builder.HasOne(i => i.user)
                .WithMany(u => u.inventoryLog)
                .HasForeignKey(i => i.UserId);

            builder.HasOne(i => i.product)
                .WithMany(p => p.inventoryLog)
                .HasForeignKey(i => i.ProductId);
        }
    }
}
