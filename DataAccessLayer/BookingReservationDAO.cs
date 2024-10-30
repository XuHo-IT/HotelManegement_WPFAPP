using BussinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingReservationDAO
    {
        private static BookingReservationDAO? instance = null;
        private static readonly object instanceLock = new object();
        private HotelManagementContext _context;

        public static BookingReservationDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookingReservationDAO();
                    }
                    return instance;
                }
            }
        }


        private BookingReservationDAO() { }


        public List<BookingReservation> GetAllBookingReservations()
        {
            _context = new HotelManagementContext();
            return _context.BookingReservations.ToList(); ;
        }


        public int AddBookingReservations(BookingReservation bookingReservation)
        {
            using (var _context = new HotelManagementContext())
            {
                _context.BookingReservations.Add(bookingReservation);
                _context.SaveChanges();
            }
            return bookingReservation.BookingReservationID; // Return the newly generated ID
        }

        public BookingReservation GetBookingReservationById(int id)
        {
            using (_context = new HotelManagementContext())
            {
                return _context.BookingReservations.Find(id);
            }
        }
        public void UpdateBookingReservation(BookingReservation bookingReservation)
        {
            using (_context = new HotelManagementContext())
            {
                _context.BookingReservations.Update(bookingReservation);
                _context.SaveChanges();
            }
        }
        public void DeleteBookingReservation(int id)
        {
            using (_context = new HotelManagementContext())
            {
                var reservation = _context.BookingReservations.Find(id);
                if (reservation != null)
                {
                    _context.BookingReservations.Remove(reservation);
                    _context.SaveChanges();
                }
            }
        }
        public List<BookingReservation> GetReservationsByUserId(int userId)
        {
            using (_context = new HotelManagementContext())
            {
                return _context.BookingReservations
                    .Where(r => r.CustomerID == userId)
                    .ToList();
            }
        }

        public List<BookingReservation> GetUserBills(int customerId)
        {
            using (_context = new HotelManagementContext())
            {
                return _context.BookingReservations
                    .Where(r => r.CustomerID == customerId && r.BookingStatus == 1)
                    .ToList();
            }
        }
      
        public List<BookingReservation> GetBookingsByPeriod(DateTime startDate, DateTime endDate)
        {
            using (_context = new HotelManagementContext())
            {
                return _context.BookingReservations
                    .Where(r => r.BookingDate >= startDate && r.BookingDate <= endDate)
                    .OrderByDescending(r => r.BookingDate)
                    .ToList();
            }
        }
        public List<BookingDetail> GetUserBillDetails(int bookingReservationID)
        {
            using (_context = new HotelManagementContext())
            {
                return _context.BookingDetails
                    .Where(d => d.BookingReservationID == bookingReservationID)
                    .ToList();
            }
        }

    }
}
