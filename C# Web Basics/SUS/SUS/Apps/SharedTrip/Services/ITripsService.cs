using System.Collections.Generic;

using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void Create(AddTripInputModel trip);

        IEnumerable<TripViewModel> GetAll();

        TripDetailsViewModel GetDetails(string id);

        bool HasAvailableSeats(string tripId);

        bool AddUserToTrip(string userId, string tripId);
    }
}
