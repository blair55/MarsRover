using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Interfaces
{
    public interface IInstruction
    {
        void Execute(IRover Rover);
    }
}