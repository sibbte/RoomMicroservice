using RoomMicroservice.Enum;
using RoomMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RoomMicroservice.Managers
{
    public class RoomManager
    {
        private readonly CatContext _context;

        public RoomManager(CatContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public Room Find(Guid id)
        {
            return _context.Rooms.Find(id);
        }

        public IEnumerable<Room> GetAllByNumber()
        {
            return _context.Rooms.OrderBy(x => x.RoomNo).OrderBy(x => x.RoomType).ToList();
        }

        public IEnumerable<Room> GetAllByRoomType(RoomType roomType)
        {
            IList<Room> result = new List<Room>();
            var room = GetAllByNumber().OrderBy(x => x.RoomType).ToList();
            for (int i = 0; i < room.Count(); i++)
            {
                if (room[i].RoomType == roomType)
                {
                    result.Add(room[i]);
                }
            }
            if (result.Count() != 0)
            {
                return result.ToList();
            }
            else
            {
                throw new DataException($"No Rooms with the '{roomType}'.");
            }
        }

        public void Create(Room room)
        {
            var roomList = GetAllByNumber().OrderBy(x => x.RoomNo).ToList();
            for (int i = 0; i < roomList.Count(); i++)
            {
                if (roomList[i].RoomNo == room.RoomNo)
                {
                    throw new DataException($"Room {room.RoomNo}, Already Exsists");
                }
            }
            if (room.RoomType == RoomType.FamilyRoom && room.MaxNoOfCatsInRoom > 4 || room.RoomType == RoomType.StandardRoom && room.MaxNoOfCatsInRoom > 2)
            {
                throw new DataException("Family room can hold a maximum of 4 cats at a time and standard rooms can hold maximum of 2 cats.");
            }
            else
            {
                room.CheckedIn = false;
                room.CheckedOut = false;
                room.BookingEnd = DateTime.Now;
                room.BookingStart = DateTime.Now;
                room.Booked = false;
                room.Available = true;
                room.ID = Guid.NewGuid();
                _context.Add(room);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Room> GetByRoomNumber(int roomNumber)
        {
            IList<Room> result = new List<Room>();
            var room = GetAllByNumber().OrderBy(x => x.RoomNo).ToList();
            for (int i = 0; i < room.Count(); i++)
            {
                if (room[i].RoomNo == roomNumber)
                {
                    result.Add(room[i]);
                }
            }
            if (result.Count() != 0)
            {
                return result.ToList();
            }
            else
            {
                throw new DataException($"No Rooms with the '{roomNumber}'.");
            }
        }



    }
}
