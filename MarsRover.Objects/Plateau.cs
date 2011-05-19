using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;
using MarsRover.Interfaces.EventArguments;
using MarsRover.Objects.PositionChecks;

namespace MarsRover.Objects
{
    public class Plateau : IPlateau
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}