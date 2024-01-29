using BusTerminalProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTerminalProject.EnitityMap
{
    public class TicketEntityMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).UseIdentityColumn();
            builder.Property(_ => _.PassangerFirstName).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.PassengerLastName).HasMaxLength(50).IsRequired();
            builder.HasOne(_ => _.Trip).WithMany(_ => _.Tickets)
                .HasForeignKey(_ => _.TripId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
