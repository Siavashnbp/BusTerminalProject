using BusTerminalProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTerminalProject.EnitityMap
{
    public class BusSeatEntityMap : IEntityTypeConfiguration<BusSeat>
    {
        public void Configure(EntityTypeBuilder<BusSeat> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).UseIdentityColumn();
            builder.Property(_ => _.PassangerFullName).HasMaxLength(100);
            builder.HasOne(_ => _.Bus).WithMany(_ => _.BusSeats)
                .HasForeignKey(_ => _.BusId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
