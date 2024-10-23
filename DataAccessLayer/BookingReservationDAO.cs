using BussinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class BookingReservationDAO
    {
        private string connectionString;

        public BookingReservationDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<BookingReservation> GetAllBookingReservations()
        {
            List<BookingReservation> reservations = new List<BookingReservation>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM BookingReservation";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BookingReservation reservation = new BookingReservation
                        {
                            BookingReservationID = reader.GetInt32(reader.GetOrdinal("BookingReservationID")),
                            BookingDate = reader.IsDBNull(reader.GetOrdinal("BookingDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                            TotalPrice = reader.IsDBNull(reader.GetOrdinal("TotalPrice")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                            CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                            BookingStatus = reader.IsDBNull(reader.GetOrdinal("BookingStatus")) ? (byte?)null : reader.GetByte(reader.GetOrdinal("BookingStatus"))
                        };

                        reservations.Add(reservation);
                    }
                }
            }

            return reservations;
        }
        public void AddBookingReservation(BookingReservation bookingReservation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO BookingReservation (BookingDate, TotalPrice, CustomerID, BookingStatus) VALUES (@BookingDate, @TotalPrice, @CustomerID, @BookingStatus)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookingDate", bookingReservation.BookingDate);
                command.Parameters.AddWithValue("@TotalPrice", bookingReservation.TotalPrice);
                command.Parameters.AddWithValue("@CustomerID", bookingReservation.CustomerID);
                command.Parameters.AddWithValue("@BookingStatus", bookingReservation.BookingStatus);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private int SaveBookingReservation(BookingReservation bookingReservation)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO BookingReservation (BookingDate, TotalPrice, CustomerID, BookingStatus) " +
                               "OUTPUT INSERTED.BookingReservationID VALUES (@BookingDate, @TotalPrice, @CustomerID, @BookingStatus)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookingDate", bookingReservation.BookingDate);
                    command.Parameters.AddWithValue("@TotalPrice", bookingReservation.TotalPrice);
                    command.Parameters.AddWithValue("@CustomerID", bookingReservation.CustomerID);
                    command.Parameters.AddWithValue("@BookingStatus", bookingReservation.BookingStatus);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

    }
}
