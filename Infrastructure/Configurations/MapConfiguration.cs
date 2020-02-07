using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
    public class MapConfiguration : IEntityTypeConfiguration<Map>
    {
        public void Configure(EntityTypeBuilder<Map> builder)
        {
            //builder.OwnsOne(x => x.Center);

            builder.OwnsOne(o => o.Center, x =>
            {
                x.Property(p => p.Latitude).IsRequired().HasColumnName("Latitude");
                x.Property(p => p.Longitude).IsRequired().HasColumnName("Longitude");
            });

            builder.HasMany(m => m.Markers).WithOne(r => r.Map).HasForeignKey(f => f.MapId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(m => m.Shapes).WithOne(r => r.Map).HasForeignKey(f => f.MapId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
