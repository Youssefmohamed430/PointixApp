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
    internal class UserNotificationConfiguration : IEntityTypeConfiguration<UserNotification>
    {
        public void Configure(EntityTypeBuilder<UserNotification> builder)
        {
            builder.HasKey(un => new { un.UserId , un.NotifId });

            builder.HasOne(x => x.user)
                .WithMany(x => x.userNotification)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.notification)
                .WithMany(x => x.userNotification)
                .HasForeignKey(x => x.NotifId);
        }
    }
}
