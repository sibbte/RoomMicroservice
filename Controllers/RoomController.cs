using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RoomMicroservice.Enum;
using RoomMicroservice.Managers;
using RoomMicroservice.Models;
using RoomMicroservice.Validators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RoomMicroservice.Controllers
{
    public class RoomController : ControllerBase
    {

        private readonly RoomManager roomManager;
        private readonly CatContext _context;
        private readonly RoomValidator validator = new RoomValidator();

        public RoomController(CatContext context)
        {
            _context = context;
            roomManager = new RoomManager(_context);

        }

        [HttpGet]
        [Route("Api/Room/GetAll")]
        public IEnumerable<Room> GetAll()
        {
            System.Console.WriteLine("Api/Room/GetAll");
            return roomManager.GetAllRooms().OrderBy(x => x.RoomNo).ToList();
        }

        [HttpGet]
        [Route("Api/Room/GetById")]
        public Room GetById(Guid room)
        {

            return roomManager.Find(room);
        }

        [HttpGet]
        [Route("Api/Room/GetAllByNumber")]
        public IEnumerable<Room> GetAllByNumber()
        {
            if (roomManager.GetAllByNumber().ToList().Count() == 0)
            {
                throw new DataException("error");
            }
            else
            {
                System.Console.WriteLine("Room/GetAllByNumber");
                return roomManager.GetAllByNumber().ToList();
            }


        }

        [HttpGet]
        [Route("Api/Room/GetAllByRoomType")]
        public IEnumerable<Room> GetAllByRoomType(RoomType roomType)
        {
            if (roomManager.GetAllByRoomType(roomType).ToList().Count() == 0)
            {
                throw new DataException("error");
            }
            else
            {
                return roomManager.GetAllByRoomType(roomType).ToList();
            }

        }

        [HttpGet]
        [Route("Api/Room/GetByRoomNumber")]
        public IEnumerable<Room> GetByRoomNumber(int roomNum)
        {
            if (roomManager.GetByRoomNumber(roomNum).ToList().Count() == 0)
            {
                throw new DataException("error");
            }
            else
            {
                return roomManager.GetByRoomNumber(roomNum).ToList();
            }

        }

        [HttpPost]
        [Route("Api/Room/AddRoom")]
        public ActionResult Create(int roomNo, RoomType roomType, int maxNoOfCats, string user)
        {
            Room room = new Room()
            {
                RoomNo = roomNo,
                RoomType = roomType,
                MaxNoOfCatsInRoom = maxNoOfCats,
                UserId = user
            };
            ValidationResult result = validator.Validate(room);
            if (!result.IsValid)
            {
                validator.ValidateAndThrow(room);
            }
            else if (ModelState.IsValid)
            {
                roomManager.Create(room);
                return Ok(room);
            }//TODO: Exception message
            throw new DataException("error");
        }

        [HttpPost]
        [Route("Api/Room/Edit")]
        public ActionResult Edit(int roomNo, RoomType roomType, int maxNoOfCats, Guid id)
        {
            Room room = new Room()
            {
                RoomNo = roomNo,
                RoomType = roomType,
                MaxNoOfCatsInRoom = maxNoOfCats,
                //User = user
            };
            ValidationResult result = validator.Validate(room);
            if (!result.IsValid)
            {
                validator.ValidateAndThrow(room);
            }
            if (ModelState.IsValid)
            {
                roomManager.Create(room);
                return Ok(room);
            }
            else
            {
                throw new DataException("");
            }
        }
    }
}
