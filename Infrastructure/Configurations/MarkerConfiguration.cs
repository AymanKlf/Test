using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
    public class MarkerConfiguration : IEntityTypeConfiguration<Marker>
    {
        public void Configure(EntityTypeBuilder<Marker> builder)
        {
            builder.OwnsOne(o => o.Position, x =>
            {
                x.Property(p => p.Latitude).IsRequired().HasColumnName("Latitude");
                x.Property(p => p.Longitude).IsRequired().HasColumnName("Longitude");
            });

            builder.Property(p => p.Name).HasMaxLength(50).IsRequired().IsUnicode(true);
            builder.Property(p => p.Address).HasMaxLength(250).IsRequired().IsUnicode(true);

            builder.Property(p => p.MapId).IsRequired();
            builder.HasOne(r => r.Map).WithMany(m => m.Markers).HasForeignKey(f => f.MapId);
        }
    }
}
