using BussinessObject;
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
        private readonly string connectionString;

    public BookingDetailRepository(string connectionString)
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

    public BookingDetail GetBookingDetailById(int id)
    {
        BookingDetail bookingDetail = null;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM BookingDetail WHERE BookingReservationID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    bookingDetail = new BookingDetail
                    {
                        BookingReservationID = reader.GetInt32(reader.GetOrdinal("BookingReservationID")),
                        RoomID = reader.GetInt32(reader.GetOrdinal("RoomID")),
                        StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                        EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                        ActualPrice = reader.IsDBNull(reader.GetOrdinal("ActualPrice")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("ActualPrice"))
                    };
                }
            }
        }
        return bookingDetail;
    }

    public void AddBookingDetail(BookingDetail bookingDetail)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO BookingDetail (BookingReservationID, RoomID, StartDate, EndDate, ActualPrice) VALUES (@BookingReservationID, @RoomID, @StartDate, @EndDate, @ActualPrice)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BookingReservationID", bookingDetail.BookingReservationID);
            command.Parameters.AddWithValue("@RoomID", bookingDetail.RoomID);
            command.Parameters.AddWithValue("@StartDate", bookingDetail.StartDate);
            command.Parameters.AddWithValue("@EndDate", bookingDetail.EndDate);
            command.Parameters.AddWithValue("@ActualPrice", bookingDetail.ActualPrice);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void UpdateBookingDetail(BookingDetail bookingDetail)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE BookingDetail SET RoomID = @RoomID, StartDate = @StartDate, EndDate = @EndDate, ActualPrice = @ActualPrice WHERE BookingReservationID = @BookingReservationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BookingReservationID", bookingDetail.BookingReservationID);
            command.Parameters.AddWithValue("@RoomID", bookingDetail.RoomID);
            command.Parameters.AddWithValue("@StartDate", bookingDetail.StartDate);
            command.Parameters.AddWithValue("@EndDate", bookingDetail.EndDate);
            command.Parameters.AddWithValue("@ActualPrice", bookingDetail.ActualPrice);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void DeleteBookingDetail(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM BookingDetail WHERE BookingReservationID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
    
}
