using BussinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BookingDetailService : IBookingDetailRepository
    {
        private readonly IBookingDetailRepository bookingDetailRepository;

        public BookingDetailService(IBookingDetailRepository bookingDetailRepository)
        {
            this.bookingDetailRepository = bookingDetailRepository;
        }

        public List<BookingDetail> GetAllBookingDetails()
        {
            return bookingDetailRepository.GetAllBookingDetails();
        }

        public BookingDetail GetBookingDetailById(int id)
        {
            return bookingDetailRepository.GetBookingDetailById(id);
        }

        public void AddBookingDetail(BookingDetail bookingDetail)
        {
            bookingDetailRepository.AddBookingDetail(bookingDetail);
        }

        public void UpdateBookingDetail(BookingDetail bookingDetail)
        {
            bookingDetailRepository.UpdateBookingDetail(bookingDetail);
        }

        public void DeleteBookingDetail(int id)
        {
            bookingDetailRepository.DeleteBookingDetail(id);
        }
    }
}
