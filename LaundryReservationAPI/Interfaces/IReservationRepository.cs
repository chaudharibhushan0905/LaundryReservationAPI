using LaundryReservationAPI.Models;

namespace LaundryReservationAPI.Interfaces
{
    public interface IReservationRepository
    {
        Task<bool> AddReservationAsync(Reservation reservation);
        string GenerateRandomPin();
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationAsync(string email, string phone);
        Task<bool> UpdateReservationAsync(Reservation reservation);
        Task<bool> SaveChangesAsync();
    }
}
