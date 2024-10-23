using BussinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RoomInformationService : IRoomInformationRepository
    {
        private readonly IRoomInformationRepository roomInformationRepository;

        public RoomInformationService(IRoomInformationRepository roomInformationRepository)
        {
            this.roomInformationRepository = roomInformationRepository;
        }

        public List<RoomInformation> GetAllRoomInformation()
        {
            return roomInformationRepository.GetAllRoomInformation();
        }

        public RoomInformation GetRoomInformationById(int id)
        {
            return roomInformationRepository.GetRoomInformationById(id);
        }

        public void AddRoomInformation(RoomInformation roomInformation)
        {
            roomInformationRepository.AddRoomInformation(roomInformation);
        }

        public void UpdateRoomInformation(RoomInformation roomInformation)
        {
            roomInformationRepository.UpdateRoomInformation(roomInformation);
        }

        public void DeleteRoomInformation(int id)
        {
            roomInformationRepository.DeleteRoomInformation(id);
        }
    }
}
