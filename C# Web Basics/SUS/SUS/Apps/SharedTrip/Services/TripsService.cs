using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(AddTripInputModel trip)
        {
            var dbTrip = new Trip
            {
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                ImagePath = trip.ImagePath,
                DepartureTime = trip.DepartureTime,
                Description = trip.Description,
                Seats = (byte)trip.Seats
            };

            this.db.Trips.Add(dbTrip);
            this.db.SaveChanges();
        }
    }
}
