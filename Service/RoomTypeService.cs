using BussinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class RoomTypeService : IRoomTypeRepository
    {
        private readonly IRoomTypeRepository roomTypeRepository;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository)
        {
            this.roomTypeRepository = roomTypeRepository;
        }

        public List<RoomType> GetAllRoomTypes()
        {
            return roomTypeRepository.GetAllRoomTypes();
        }

        public RoomType GetRoomTypeById(int id)
        {
            return roomTypeRepository.GetRoomTypeById(id);
        }

        public void AddRoomType(RoomType roomType)
        {
            roomTypeRepository.AddRoomType(roomType);
        }

        public void UpdateRoomType(RoomType roomType)
        {
            roomTypeRepository.UpdateRoomType(roomType);
        }

        public void DeleteRoomType(int id)
        {
            roomTypeRepository.DeleteRoomType(id);
        }
    }
}
