using BussinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly string connectionString;

        public RoomTypeRepository(string connectionString)
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

        public RoomType GetRoomTypeById(int id)
        {
            RoomType roomType = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM RoomType WHERE RoomTypeID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        roomType = new RoomType
                        {
                            RoomTypeID = reader.GetInt32(reader.GetOrdinal("RoomTypeID")),
                            RoomTypeName = reader.GetString(reader.GetOrdinal("RoomTypeName")),
                            TypeDescription = reader.GetString(reader.GetOrdinal("TypeDescription")),
                            TypeNote = reader.GetString(reader.GetOrdinal("TypeNote"))
                        };
                    }
                }
            }
            return roomType;
        }

        public void AddRoomType(RoomType roomType)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO RoomType (RoomTypeName, TypeDescription, TypeNote) VALUES (@RoomTypeName, @TypeDescription, @TypeNote)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomTypeName", roomType.RoomTypeName);
                command.Parameters.AddWithValue("@TypeDescription", roomType.TypeDescription);
                command.Parameters.AddWithValue("@TypeNote", roomType.TypeNote);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateRoomType(RoomType roomType)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE RoomType SET RoomTypeName = @RoomTypeName, TypeDescription = @TypeDescription, TypeNote = @TypeNote WHERE RoomTypeID = @RoomTypeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomTypeID", roomType.RoomTypeID);
                command.Parameters.AddWithValue("@RoomTypeName", roomType.RoomTypeName);
                command.Parameters.AddWithValue("@TypeDescription", roomType.TypeDescription);
                command.Parameters.AddWithValue("@TypeNote", roomType.TypeNote);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteRoomType(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM RoomType WHERE RoomTypeID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
