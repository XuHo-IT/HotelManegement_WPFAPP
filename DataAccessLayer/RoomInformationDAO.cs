using BussinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class RoomInformationDAO
    {
        private string connectionString;

        public RoomInformationDAO(string connectionString)
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
    }
}
