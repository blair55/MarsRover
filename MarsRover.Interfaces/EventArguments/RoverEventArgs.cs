using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Interfaces.EventArguments
{
    public delegate void RoverMoveEventHandler(object sender, RoverEventArgs e);

    public class RoverEventArgs : EventArgs
    {
        IRover _rover;

        public IRover Rover
        {
            get { return this._rover; }
        }

        public RoverEventArgs(IRover rover)
        {
            this._rover = rover;
        }
    }
}