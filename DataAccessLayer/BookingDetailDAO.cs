using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class BookingDetailDAO
    {
        private static BookingDetailDAO? instance = null;
        private static readonly object instanceLock = new object();
        private HotelManagementContext _context;

        public static BookingDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookingDetailDAO();
                    }
                    return instance;
                }
            }
        }

        private BookingDetailDAO() { }

        public void AddBookingDetail(BookingDetail bookingDetail)
        {
            _context = new HotelManagementContext();
            _context.BookingDetails.Add(bookingDetail);
            _context.SaveChanges();
        }

        public void UpdateBookingDetail(BookingDetail bookingDetail)
        {
            _context = new HotelManagementContext();
            _context.BookingDetails.Update(bookingDetail);
            _context.SaveChanges();
        }

        public void DeleteBookingDetail(int bookingReservationID)
        {
            _context = new HotelManagementContext();
            var bookingDetail = _context.BookingDetails.FirstOrDefault(b => b.BookingReservationID == bookingReservationID);
            if (bookingDetail != null)
            {
                _context.BookingDetails.Remove(bookingDetail);
                _context.SaveChanges();
            }
        }

        public List<BookingDetail> GetAllBookingDetails()
        {
            _context = new HotelManagementContext();
            return _context.BookingDetails.ToList();
        }
     
        public BookingDetail? GetBookingDetailById(int bookingReservationID)
        {
            _context = new HotelManagementContext();
            return _context.BookingDetails.FirstOrDefault(b => b.BookingReservationID == bookingReservationID);
        }
    }
}
