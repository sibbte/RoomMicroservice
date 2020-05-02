using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoomMicroservice.Enum
{
    public enum RoomType
    {
        [Display(Name = "Family Room")]
        FamilyRoom = 1,
        [Display(Name = "Standard Room")]
        StandardRoom = 2
    }

}
