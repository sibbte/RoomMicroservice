using FluentValidation;
using RoomMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomMicroservice.Validators
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(x => x.RoomNo).NotEmpty().NotEqual(0).LessThan(11).WithMessage(room => $"Only rooms number 1-10 exsist, {room.RoomNo} doesnt exsist.");
            RuleFor(x => x.MaxNoOfCatsInRoom).NotNull().LessThan(5).NotEqual(0).WithMessage(room => $"The Minimum Number of cats per room is 1 and the maximum is 4. {room.MaxNoOfCatsInRoom} is a invalid number to choose");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Users Details must be provided");
        }
    }
}
