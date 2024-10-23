using BussinessObject;
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
        private readonly string connectionString;

        public BookingReservationRepository(string connectionString)
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

        public BookingReservation GetBookingReservationById(int id)
        {
            BookingReservation reservation = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM BookingReservation WHERE BookingReservationID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        reservation = new BookingReservation
                        {
                            BookingReservationID = reader.GetInt32(reader.GetOrdinal("BookingReservationID")),
                            BookingDate = reader.IsDBNull(reader.GetOrdinal("BookingDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                            TotalPrice = reader.IsDBNull(reader.GetOrdinal("TotalPrice")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                            CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                            BookingStatus = reader.IsDBNull(reader.GetOrdinal("BookingStatus")) ? (byte?)null : reader.GetByte(reader.GetOrdinal("BookingStatus"))
                        };
                    }
                }
            }
            return reservation;
        }

        public void UpdateBookingReservation(BookingReservation bookingReservation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE BookingReservation SET BookingDate = @BookingDate, TotalPrice = @TotalPrice, CustomerID = @CustomerID, BookingStatus = @BookingStatus WHERE BookingReservationID = @BookingReservationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookingDate", bookingReservation.BookingDate);
                command.Parameters.AddWithValue("@TotalPrice", bookingReservation.TotalPrice);
                command.Parameters.AddWithValue("@CustomerID", bookingReservation.CustomerID);
                command.Parameters.AddWithValue("@BookingStatus", bookingReservation.BookingStatus);
                command.Parameters.AddWithValue("@BookingReservationID", bookingReservation.BookingReservationID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteBookingReservation(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM BookingReservation WHERE BookingReservationID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public int AddBookingReservation(BookingReservation bookingReservation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO BookingReservation (BookingDate, TotalPrice, CustomerID, BookingStatus) " +
                               "OUTPUT INSERTED.BookingReservationID VALUES (@BookingDate, @TotalPrice, @CustomerID, @BookingStatus)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookingDate", bookingReservation.BookingDate);
                command.Parameters.AddWithValue("@TotalPrice", bookingReservation.TotalPrice);
                command.Parameters.AddWithValue("@CustomerID", bookingReservation.CustomerID);
                command.Parameters.AddWithValue("@BookingStatus", bookingReservation.BookingStatus);
                connection.Open();
                return (int)command.ExecuteScalar(); // Return the new BookingReservationID
            }
        }
        public List<BookingReservation> GetReservationsByUserId(int userId)
        {
           
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM BookingReservations WHERE CustomerID = @CustomerID", connection);
                command.Parameters.AddWithValue("@CustomerID", userId);

                var reader = command.ExecuteReader();
                var reservations = new List<BookingReservation>();

                while (reader.Read())
                {
                    reservations.Add(new BookingReservation
                    {
                        BookingReservationID = reader.GetInt32(reader.GetOrdinal("BookingReservationID")),
                        BookingDate = reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                        TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                        BookingStatus = (byte?)reader.GetInt32(reader.GetOrdinal("BookingStatus")),
                        CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID"))
                    });
                }

                return reservations;
            }
        }
        public List<BookingReservation> GetUserBills(int customerId)
        {
            var userBills = new List<BookingReservation>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM BookingReservation WHERE CustomerID = @CustomerId AND BookingStatus = 1";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var bill = new BookingReservation
                            {
                                BookingReservationID = reader.GetInt32(reader.GetOrdinal("BookingReservationID")),
                                BookingDate = reader.IsDBNull(reader.GetOrdinal("BookingDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                                TotalPrice = reader.IsDBNull(reader.GetOrdinal("TotalPrice")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                                CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                BookingStatus = reader.IsDBNull(reader.GetOrdinal("BookingStatus")) ? (byte?)null : reader.GetByte(reader.GetOrdinal("BookingStatus"))
                            };
                            userBills.Add(bill);
                        }
                    }
                }
            }

            return userBills;
        }

        public List<BookingDetail> GetUserBillDetails(int bookingReservationID)
        {
            List<BookingDetail> billDetails = new List<BookingDetail>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM BookingDetail WHERE BookingReservationID = @BookingReservationID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingReservationID", bookingReservationID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BookingDetail detail = new BookingDetail
                            {
                                BookingReservationID = reader.GetInt32(reader.GetOrdinal("BookingReservationID")),
                                RoomID = reader.GetInt32(reader.GetOrdinal("RoomID")),
                                StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                ActualPrice = reader.IsDBNull(reader.GetOrdinal("ActualPrice")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("ActualPrice")),
                            };
                            billDetails.Add(detail);
                        }
                    }
                }
            }
            return billDetails;
        }
        public List<BookingReservation> GetBookingsByPeriod(DateTime startDate, DateTime endDate)
        {
            var reservations = new List<BookingReservation>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT BookingReservationID, BookingDate, TotalPrice, CustomerID, BookingStatus " +
                               "FROM BookingReservation " +
                               "WHERE BookingDate BETWEEN @StartDate AND @EndDate " +
                               "ORDER BY BookingDate DESC"; 

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var reservation = new BookingReservation
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
            }

            return reservations;
        }


    }
}
