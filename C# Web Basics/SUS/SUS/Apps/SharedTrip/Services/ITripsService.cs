using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void Create(AddTripInputModel trip);
    }
}
