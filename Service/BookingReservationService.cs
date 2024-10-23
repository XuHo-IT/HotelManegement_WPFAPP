using BussinessObject;
using Microsoft.Data.SqlClient;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BookingReservationService : IBookingReservationRepository
    {
        private readonly IBookingReservationRepository bookingReservationRepository;

        public BookingReservationService(IBookingReservationRepository bookingReservationRepository)
        {
            this.bookingReservationRepository = bookingReservationRepository;
        }

        public List<BookingReservation> GetAllBookingReservations()
        {
            return bookingReservationRepository.GetAllBookingReservations();
        }

        public BookingReservation GetBookingReservationById(int id)
        {
            return bookingReservationRepository.GetBookingReservationById(id);
        }

        public void UpdateBookingReservation(BookingReservation bookingReservation)
        {
            bookingReservationRepository.UpdateBookingReservation(bookingReservation);
        }

        public List<BookingReservation> GetBookingsByPeriod(DateTime startDate, DateTime endDate)
        {
            return bookingReservationRepository.GetBookingsByPeriod(startDate, endDate);
        }

        public void DeleteBookingReservation(int id)
        {
            bookingReservationRepository.DeleteBookingReservation(id);
        }
        public int AddBookingReservation(BookingReservation bookingReservation)
        {
            return bookingReservationRepository.AddBookingReservation(bookingReservation); 
        }
    }
}
