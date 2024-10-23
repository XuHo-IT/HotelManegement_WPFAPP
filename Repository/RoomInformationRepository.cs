using BussinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoomInformationRepository : IRoomInformationRepository
    {
        private readonly string connectionString;

        public RoomInformationRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<RoomInformation> GetAllRoomInformation()
        {
            List<RoomInformation> roomInformationList = new List<RoomInformation>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM RoomInformation";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RoomInformation roomInformation = new RoomInformation
                        {
                            RoomID = reader.GetInt32(reader.GetOrdinal("RoomID")),
                            RoomNumber = reader.GetString(reader.GetOrdinal("RoomNumber")),
                            RoomDetailDescription = reader.GetString(reader.GetOrdinal("RoomDetailDescription")),
                            RoomMaxCapacity = reader.GetInt32(reader.GetOrdinal("RoomMaxCapacity")),
                            RoomTypeID = reader.GetInt32(reader.GetOrdinal("RoomTypeID")),
                            RoomStatus = reader.GetByte(reader.GetOrdinal("RoomStatus")),
                            RoomPricePerDay = reader.GetDecimal(reader.GetOrdinal("RoomPricePerDay"))
                        };
                        roomInformationList.Add(roomInformation);
                    }
                }
            }
            return roomInformationList;
        }

        public RoomInformation GetRoomInformationById(int id)
        {
            RoomInformation roomInformation = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM RoomInformation WHERE RoomID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        roomInformation = new RoomInformation
                        {
                            RoomID = reader.GetInt32(reader.GetOrdinal("RoomID")),
                            RoomNumber = reader.GetString(reader.GetOrdinal("RoomNumber")),
                            RoomDetailDescription = reader.GetString(reader.GetOrdinal("RoomDetailDescription")),
                            RoomMaxCapacity = reader.GetInt32(reader.GetOrdinal("RoomMaxCapacity")),
                            RoomTypeID = reader.GetInt32(reader.GetOrdinal("RoomTypeID")),
                            RoomStatus = reader.GetByte(reader.GetOrdinal("RoomStatus")),
                            RoomPricePerDay = reader.GetDecimal(reader.GetOrdinal("RoomPricePerDay"))
                        };
                    }
                }
            }
            return roomInformation;
        }

        public void AddRoomInformation(RoomInformation roomInformation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO RoomInformation (RoomNumber, RoomDetailDescription, RoomMaxCapacity, RoomTypeID, RoomStatus, RoomPricePerDay) VALUES (@RoomNumber, @RoomDetailDescription, @RoomMaxCapacity, @RoomTypeID, @RoomStatus, @RoomPricePerDay)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomNumber", roomInformation.RoomNumber);
                command.Parameters.AddWithValue("@RoomDetailDescription", roomInformation.RoomDetailDescription);
                command.Parameters.AddWithValue("@RoomMaxCapacity", roomInformation.RoomMaxCapacity);
                command.Parameters.AddWithValue("@RoomTypeID", roomInformation.RoomTypeID);
                command.Parameters.AddWithValue("@RoomStatus", roomInformation.RoomStatus);
                command.Parameters.AddWithValue("@RoomPricePerDay", roomInformation.RoomPricePerDay);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateRoomInformation(RoomInformation roomInformation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE RoomInformation SET RoomNumber = @RoomNumber, RoomDetailDescription = @RoomDetailDescription, RoomMaxCapacity = @RoomMaxCapacity, RoomTypeID = @RoomTypeID, RoomStatus = @RoomStatus, RoomPricePerDay = @RoomPricePerDay WHERE RoomID = @RoomID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomID", roomInformation.RoomID);
                command.Parameters.AddWithValue("@RoomNumber", roomInformation.RoomNumber);
                command.Parameters.AddWithValue("@RoomDetailDescription", roomInformation.RoomDetailDescription);
                command.Parameters.AddWithValue("@RoomMaxCapacity", roomInformation.RoomMaxCapacity);
                command.Parameters.AddWithValue("@RoomTypeID", roomInformation.RoomTypeID);
                command.Parameters.AddWithValue("@RoomStatus", roomInformation.RoomStatus);
                command.Parameters.AddWithValue("@RoomPricePerDay", roomInformation.RoomPricePerDay);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteRoomInformation(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM RoomInformation WHERE RoomID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
