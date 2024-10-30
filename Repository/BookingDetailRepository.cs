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
    public class BookingDetailRepository : IBookingDetailRepository
    {

        public List<BookingDetail> GetAllBookingDetails() => BookingDetailDAO.Instance.GetAllBookingDetails();

        public BookingDetail GetBookingDetailById(int id) => BookingDetailDAO.Instance.GetBookingDetailById(id);

        public void AddBookingDetail(BookingDetail bookingDetail) => BookingDetailDAO.Instance.AddBookingDetail(bookingDetail);

        public void UpdateBookingDetail(BookingDetail bookingDetail) => BookingDetailDAO.Instance.UpdateBookingDetail(bookingDetail);

        public void DeleteBookingDetail(int id) => BookingDetailDAO.Instance.DeleteBookingDetail(id);

    }
}
    
