using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomMicroservice.Models
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<CatContext>());
            }

        }

        public static void SeedData(CatContext context)
        {
            System.Console.WriteLine("Appling Migrations...");

            context.Database.Migrate();
            Room room = new Room()
            {
                Available = false,
                Booked = false,
                BookingEnd = DateTime.Now,
                BookingStart = DateTime.Now,
                CheckedIn = false,
                CheckedOut = false,
                RoomType = Enum.RoomType.StandardRoom,
                MaxNoOfCatsInRoom = 2,
                RoomNo = 1,
                UserId = "system"
            };
            Room room1 = new Room()
            {
                Available = false,
                Booked = false,
                BookingEnd = DateTime.Now,
                BookingStart = DateTime.Now,
                CheckedIn = false,
                CheckedOut = false,
                RoomType = Enum.RoomType.StandardRoom,
                MaxNoOfCatsInRoom = 2,
                RoomNo = 2,
                UserId = "system"
            };
            Room room2 = new Room()
            {
                Available = false,
                Booked = false,
                BookingEnd = DateTime.Now,
                BookingStart = DateTime.Now,
                CheckedIn = false,
                CheckedOut = false,
                RoomType = Enum.RoomType.StandardRoom,
                MaxNoOfCatsInRoom = 2,
                RoomNo = 3,
                UserId = "system"
            };
            Room room3 = new Room()
            {
                Available = false,
                Booked = false,
                BookingEnd = DateTime.Now,
                BookingStart = DateTime.Now,
                CheckedIn = false,
                CheckedOut = false,
                RoomType = Enum.RoomType.StandardRoom,
                MaxNoOfCatsInRoom = 2,
                RoomNo = 4,
                UserId = "system"
            };
            Room room4 = new Room()
            {
                Available = false,
                Booked = false,
                BookingEnd = DateTime.Now,
                BookingStart = DateTime.Now,
                CheckedIn = false,
                CheckedOut = false,
                RoomType = Enum.RoomType.StandardRoom,
                MaxNoOfCatsInRoom = 2,
                RoomNo = 5,
                UserId = "system"
            };
            Room room5 = new Room()
            {
                Available = false,
                Booked = false,
                BookingEnd = DateTime.Now,
                BookingStart = DateTime.Now,
                CheckedIn = false,
                CheckedOut = false,
                RoomType = Enum.RoomType.StandardRoom,
                MaxNoOfCatsInRoom = 2,
                RoomNo = 6,
                UserId = "system"
            };
            Room room6 = new Room()
            {
                Available = false,
                Booked = false,
                BookingEnd = DateTime.Now,
                BookingStart = DateTime.Now,
                CheckedIn = false,
                CheckedOut = false,
                RoomType = Enum.RoomType.StandardRoom,
                MaxNoOfCatsInRoom = 2,
                RoomNo = 7,
                UserId = "system"
            };
            Room room7 = new Room()
            {
                Available = false,
                Booked = false,
                BookingEnd = DateTime.Now,
                BookingStart = DateTime.Now,
                CheckedIn = false,
                CheckedOut = false,
                RoomType = Enum.RoomType.FamilyRoom,
                MaxNoOfCatsInRoom = 4,
                RoomNo = 8,
                UserId = "system"
            };
            Room room8 = new Room()
            {
                Available = false,
                Booked = false,
                BookingEnd = DateTime.Now,
                BookingStart = DateTime.Now,
                CheckedIn = false,
                CheckedOut = false,
                RoomType = Enum.RoomType.FamilyRoom,
                MaxNoOfCatsInRoom = 4,
                RoomNo = 9,
                UserId = "system"
            };
            Room room9 = new Room()
            {
                Available = false,
                Booked = false,
                BookingEnd = DateTime.Now,
                BookingStart = DateTime.Now,
                CheckedIn = false,
                CheckedOut = false,
                RoomType = Enum.RoomType.FamilyRoom,
                MaxNoOfCatsInRoom = 4,
                RoomNo = 10,
                UserId = "system"
            };

            if(!context.Rooms.Any())
            {
                System.Console.WriteLine("Seeding Room Data...");
                context.Rooms.AddRange(room, room1, room2, room3, room4, room5, room6, room7, room8, room9);


                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data Room - not seeding");
            }

        }
    }
}
