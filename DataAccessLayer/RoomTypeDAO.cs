using BussinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class RoomTypeDAO
    {
        private string connectionString;

        public RoomTypeDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<RoomType> GetAllRoomTypes()
        {
            List<RoomType> roomTypes = new List<RoomType>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM RoomType";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RoomType roomType = new RoomType
                        {
                            RoomTypeID = reader.GetInt32(reader.GetOrdinal("RoomTypeID")),
                            RoomTypeName = reader.GetString(reader.GetOrdinal("RoomTypeName")),
                            TypeDescription = reader.GetString(reader.GetOrdinal("TypeDescription")),
                            TypeNote = reader.GetString(reader.GetOrdinal("TypeNote"))
                        };
                        roomTypes.Add(roomType);
                    }
                }
            }
            return roomTypes;
        }
    }
}
