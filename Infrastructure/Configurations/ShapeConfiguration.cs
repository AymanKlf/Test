using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
    public class ShapeConfiguration : IEntityTypeConfiguration<Shape>
    {
        public void Configure(EntityTypeBuilder<Shape> builder)
        {
            builder.Property(p => p.Xml).IsRequired().HasColumnType("xml");

            builder.Property(p => p.MapId).IsRequired();
            builder.HasOne(r => r.Map).WithMany(m => m.Shapes).HasForeignKey(f => f.MapId);
        }
    }
}
