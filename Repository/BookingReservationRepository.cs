using BussinessObject;
using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookingReservationRepository : IBookingReservationRepository
    {

        public BookingReservation GetBookingReservationById(int id) => BookingReservationDAO.Instance.GetBookingReservationById(id);

        public int AddBookingReservation(BookingReservation bookingReservation) => BookingReservationDAO.Instance.AddBookingReservations(bookingReservation);

        public void UpdateBookingReservation(BookingReservation bookingReservation) => BookingReservationDAO.Instance.UpdateBookingReservation(bookingReservation);

        public void DeleteBookingReservation(int id) => BookingReservationDAO.Instance.DeleteBookingReservation(id);

        public List<BookingReservation> GetReservationsByUserId(int userid) => BookingReservationDAO.Instance.GetReservationsByUserId(userid);

        public List<BookingReservation> GetUserBills(int userid) => BookingReservationDAO.Instance.GetUserBills(userid);


        public List<BookingReservation> GetBookingsByPeriod(DateTime startDate, DateTime endDate) => BookingReservationDAO.Instance.GetBookingsByPeriod(startDate, endDate);

        public List<BookingReservation> GetAllBookingReservations() => BookingReservationDAO.Instance.GetAllBookingReservations();

        public List<BookingDetail> GetUserBillDetails(int bookingReservationID) => BookingReservationDAO.Instance.GetUserBillDetails(bookingReservationID);


    }
}
