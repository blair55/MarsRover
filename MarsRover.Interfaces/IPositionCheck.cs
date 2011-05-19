using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Interfaces
{
    public interface IPositionCheck
    {
        IPlateau Plateau { get; set; }
        IRover MovedRover { get; set; }
        List<IRover> ExistingRovers { get; set; }

        void Check();
    }
}
