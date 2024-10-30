using BussinessObject;
using DataAccessLayer;
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
        public void AddRoomInformation(RoomInformation roomInformation) => RoomInformationDAO.Instance.AddRoomInformation(roomInformation);    

        public void DeleteRoomInformation(int id) => RoomInformationDAO.Instance.DeleteRoomInformation(id);   

        public List<RoomInformation> GetAllRoomInformation() => RoomInformationDAO.Instance.GetAllRoomInformation();   

        public RoomInformation GetRoomInformationById(int id) => RoomInformationDAO.Instance.GetRoomInformationById(id);

        public void UpdateRoomInformation(RoomInformation roomInformation) => RoomInformationDAO.Instance.UpdateRoomInformation(roomInformation);      
    }
}
