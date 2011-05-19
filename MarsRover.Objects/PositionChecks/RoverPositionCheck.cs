using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;

namespace MarsRover.Objects.PositionChecks
{
    public class RoverPositionException : Exception
    {
        public RoverPositionException(string message) : base(message) { }
    }

    public class RoverPositionCheck : IPositionCheck
    {
        private const string ErrorMessage = "Rover {0} has left the Plateau in the {1} dimension";

        public IPlateau Plateau { get; set; }
        public IRover MovedRover { get; set; }
        public List<IRover> ExistingRovers { get; set; }

        public void Check()
        {
            if (IsXInValid(this.MovedRover, this.Plateau))
            {
                throw new RoverPositionException(String.Format(ErrorMessage, this.MovedRover.Id, "X"));
            }

            if (IsYInValid(this.MovedRover, this.Plateau))
            {
                throw new RoverPositionException(String.Format(ErrorMessage, this.MovedRover.Id, "Y"));
            }
        }

        private static bool IsXInValid(IRover rover, IPlateau plateau)
        {
            return rover.X < 0 || rover.X > plateau.Width;
        }

        private static bool IsYInValid(IRover rover, IPlateau plateau)
        {
            return rover.Y < 0 || rover.Y > plateau.Height;
        }
    }
}