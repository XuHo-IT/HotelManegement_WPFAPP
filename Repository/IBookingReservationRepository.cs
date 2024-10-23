using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBookingReservationRepository
    {
        List<BookingReservation> GetAllBookingReservations();
        BookingReservation GetBookingReservationById(int id);
        List<BookingReservation> GetBookingsByPeriod(DateTime startDate, DateTime endDate);
        int AddBookingReservation(BookingReservation bookingReservation);
        void UpdateBookingReservation(BookingReservation bookingReservation);
        void DeleteBookingReservation(int id);
    }
}
