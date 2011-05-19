using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;
using MarsRover.Objects.PositionChecks;

namespace MarsRover.Core.Factories
{
    public static class PositionCheckFactory
    {
        internal static List<IPositionCheck> GetPositionChecks()
        {
            return new List<IPositionCheck>
            { 
                new RoverPositionCheck(),
                new RoverCollisionCheck()
            };
        }
    }
}