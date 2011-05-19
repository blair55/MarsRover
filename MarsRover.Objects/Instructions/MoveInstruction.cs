using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;

namespace MarsRover.Objects.Instructions
{
    public class MoveInstruction : IInstruction
    {
        public void Execute(IRover rover)
        {
            switch (rover.Cardinal)
            {
                case CardinalType.N:
                    rover.Y++;
                    break;
                case CardinalType.E:
                    rover.X++;
                    break;
                case CardinalType.S:
                    rover.Y--;
                    break;
                case CardinalType.W:
                    rover.X--;
                    break;
            }
        }
    }
}