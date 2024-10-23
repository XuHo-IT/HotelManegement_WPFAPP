using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataAccessLayer
{
    internal class BookingDetailDAO
    {
        private string connectionString;

        public BookingDetailDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<BookingDetail> GetAllBookingDetails()
        {
            List<BookingDetail> bookingDetails = new List<BookingDetail>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM BookingDetail";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BookingDetail bookingDetail = new BookingDetail
                        {
                            BookingReservationID = reader.GetInt32(reader.GetOrdinal("BookingReservationID")),
                            RoomID = reader.GetInt32(reader.GetOrdinal("RoomID")),
                            StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                            EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                            ActualPrice = reader.IsDBNull(reader.GetOrdinal("ActualPrice")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("ActualPrice"))
                        };
                        bookingDetails.Add(bookingDetail);
                    }
                }
            }
            return bookingDetails;
        }
        public void AddBookingDetail(BookingDetail bookingDetail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO BookingDetail (RoomID, StartDate, EndDate, ActualPrice) VALUES (@RoomID, @StartDate, @EndDate, @ActualPrice)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomID", bookingDetail.RoomID);
                command.Parameters.AddWithValue("@StartDate", bookingDetail.StartDate);
                command.Parameters.AddWithValue("@EndDate", bookingDetail.EndDate);
                command.Parameters.AddWithValue("@ActualPrice", bookingDetail.ActualPrice);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
