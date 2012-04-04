using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces.EventArguments;

namespace MarsRover.Interfaces
{
    public enum CardinalType
    {
        N, E, S, W
    }

    public interface IRover
    {
        string Id { get; }
        int X { get; set; }
        int Y { get; set; }
        CardinalType Cardinal { get; set; }
        IInstruction Instruction { get; set; }
        string GetPositionOutput();
        bool Equals(IRover rover);
        event RoverMoveEventHandler OnRoverMoved;
    }
}
