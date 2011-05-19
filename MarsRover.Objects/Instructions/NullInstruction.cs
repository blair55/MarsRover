using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;
using MarsRover.Objects;

namespace MarsRover.Objects.Instructions
{
    public class NullInstruction : IInstruction
    {
        public void Execute(IRover rover)
        {}
    }
}
