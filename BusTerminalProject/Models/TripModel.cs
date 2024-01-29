using BusTerminalProject.Models;

namespace BusTerminalProject.Entities
{
    public class TripModel
    {

        public TripModel(LocationModel origin, LocationModel destination, BusModel bus)
        {
            Origin = origin;
            Destination = destination;
            Bus = bus;
        }

        public int Id { get; set; }
        public LocationModel Origin { get; set; }
        public LocationModel Destination { get; set; }
        public BusModel Bus { get; set; }
        public decimal SeatPrice { get; set; }
        public int ReserveCancelation { get; set; }
        public int PurchaseCancelation { get; set; }
        public List<TicketModel>? Tickets { get; set; }
        public decimal GetReservePrice() => (0.3M * SeatPrice);
        public decimal CalculateTripIncome()
        {
            var totalIncome = Tickets?.Where
                (_ => _.SeatStatus == SeatStatus.Reserved || _.SeatStatus == SeatStatus.Purchased)
                .Select(_ => _.PaidPrice).Sum();
            totalIncome += Tickets?.Where
                (_ => _.SeatStatus < 0)
                .Select(_ => ((SeatStatus)((int)_.SeatStatus * -1) == SeatStatus.Purchased) ? (_.PaidPrice * 0.1M) :
                (SeatStatus)((int)_.SeatStatus * -1) == SeatStatus.Reserved ? _.PaidPrice * 0.2M : 0).Sum();
            return totalIncome ?? 0;
        }
        public void FillSeats() => Bus.FillSeats(Tickets?.Where(_ =>
        _.SeatStatus == SeatStatus.Reserved || _.SeatStatus == SeatStatus.Purchased).ToList());

    }
}
