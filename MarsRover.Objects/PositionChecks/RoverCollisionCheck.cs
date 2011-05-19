using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;

namespace MarsRover.Objects.PositionChecks
{
    public class RoverCollisionException : Exception
    {
        public RoverCollisionException(string message) : base(message) { }
    }

    public class RoverCollisionCheck : IPositionCheck
    {
        private const string ErrorMessage = "Rover {0} has collided with Rover {1}";
        
        public IPlateau Plateau { get; set; }
        public IRover MovedRover { get; set; }
        public List<IRover> ExistingRovers { get; set; }

        public void Check()
        {
            foreach (IRover existingRover in this.ExistingRovers)
            {
                if (!AreRoversEqual(existingRover, this.MovedRover)
                    && AreRoversInSameXPosition(existingRover, this.MovedRover)
                    && AreRoversInSameYPosition(existingRover, this.MovedRover))
                {
                    throw new RoverCollisionException(String.Format(ErrorMessage, this.MovedRover.Id, existingRover.Id));
                }
            }
        }

        private static bool AreRoversEqual(IRover existingRover, IRover movedRover)
        {
            return existingRover.Equals(movedRover);
        }

        private static bool AreRoversInSameXPosition(IRover existingRover, IRover movedRover)
        {
            return existingRover.X == movedRover.X;
        }

        private static bool AreRoversInSameYPosition(IRover existingRover, IRover movedRover)
        {
            return existingRover.Y == movedRover.Y;
        }
    }
}