using BussinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomInformationDAO
    {

        private static RoomInformationDAO? instance = null;
        private static readonly object instanceLock = new object();
        private HotelManagementContext _context;

        public static RoomInformationDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoomInformationDAO();
                    }
                    return instance;
                }
            }
        }


        private RoomInformationDAO() { }


        public List<RoomInformation> GetAllRoomInformation()
        {
            using (var _context = new HotelManagementContext())
            {
                return _context.RoomInformation.ToList();
            }
        }

        public RoomInformation GetRoomInformationById(int id)
        {
            using (var _context = new HotelManagementContext())
            {
                return _context.RoomInformation.Find(id);
            }
        }
        public void AddRoomInformation(RoomInformation roomInformation)
        {
            using (var _context = new HotelManagementContext())
            {
                _context.RoomInformation.Add(roomInformation);
                _context.SaveChanges();
            }
        }
        public void UpdateRoomInformation(RoomInformation roomInformation)
        {
            using (var _context = new HotelManagementContext())
            {
                _context.RoomInformation.Update(roomInformation);
                _context.SaveChanges();
            }
        }
        public void DeleteRoomInformation(int id)
        {
            using (var _context = new HotelManagementContext())
            {
                var roomInformation = _context.RoomInformation.Find(id);
                if (roomInformation != null)
                {
                    _context.RoomInformation.Remove(roomInformation);
                    _context.SaveChanges();
                }
            }
        }

    }
}
