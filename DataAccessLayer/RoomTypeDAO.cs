using BussinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomTypeDAO
    {

        private static RoomTypeDAO? instance = null;
        private static readonly object instanceLock = new object();
        private HotelManagementContext _context;

        public static RoomTypeDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoomTypeDAO();
                    }
                    return instance;
                }
            }
        }


        private RoomTypeDAO() { }


        public List<RoomType> GetAllRoomTypes()
        {
            using (var _context = new HotelManagementContext())
            {
                return _context.RoomType.ToList();
            }
        }
        public RoomType GetRoomTypeById(int id)
        {
            using (var _context = new HotelManagementContext())
            {
                return _context.RoomType.Find(id);
            }
        }
        public void AddRoomType(RoomType roomType)
        {
            using (var _context = new HotelManagementContext())
            {
                _context.RoomType.Add(roomType);
                _context.SaveChanges();
            }
        }
        public void UpdateRoomType(RoomType roomType)
        {
            using (var _context = new HotelManagementContext())
            {
                _context.RoomType.Update(roomType);
                _context.SaveChanges();
            }
        }
        public void DeleteRoomType(int id)
        {
            using (var _context = new HotelManagementContext())
            {
                var roomType = _context.RoomType.Find(id);
                if (roomType != null)
                {
                    _context.RoomType.Remove(roomType);
                    _context.SaveChanges();
                }
            }
        }

    }
}
