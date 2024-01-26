using BusTerminalProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTerminalProject.EnitityMap
{
    public class TripEntityMap : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).UseIdentityColumn();
            builder.Property(_ => _.SeatPrice).HasPrecision(10, 2);
            builder.HasOne(_ => _.Bus).WithMany(_ => _.Trips)
                .HasForeignKey(_ => _.BusId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(_ => _.Origin).WithMany(_ => _.TripsAsOrigin)
                .HasForeignKey(_ => _.OriginId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(_ => _.Destination).WithMany(_ => _.TripsAsDestination)
                .HasForeignKey(_ => _.DestinationId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
