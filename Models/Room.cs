using RoomMicroservice.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoomMicroservice.Models
{
    public class Room
    {
        public Guid ID { get; set; }
        [Display(Name = "Room Number")]
        public int RoomNo { get; set; }
        [Display(Name = "Room Type")]
        public virtual RoomType RoomType { get; set; }
        [Display(Name = "Max No. of cats ")]
        public int MaxNoOfCatsInRoom { get; set; }
        [Display(Name = "Checked In")]
        public bool CheckedIn { get; set; }
        [Display(Name = "Checked Out")]
        public bool CheckedOut { get; set; }
        public bool? Booked { get; set; }
        [Display(Name = "Booking start Date")]
        public DateTime? BookingStart { get; set; }
        [Display(Name = "Booking end Date")]
        public DateTime? BookingEnd { get; set; }
        [Display(Name = "Available")]
        public bool? Available { get; set; }
        public string UserId { get; set; }
    }
}
