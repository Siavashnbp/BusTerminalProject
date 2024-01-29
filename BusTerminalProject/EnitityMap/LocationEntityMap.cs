using BusTerminalProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTerminalProject.EnitityMap
{
    public class LocationEntityMap : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).UseIdentityColumn();
            builder.Property(_ => _.Province).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.City).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.Name).HasMaxLength(50).IsRequired();
        }
    }
}
