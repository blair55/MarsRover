using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;
using MarsRover.Interfaces.EventArguments;
using MarsRover.Objects.PositionChecks;

namespace MarsRover.Core
{
    public class PlateauController
    {
        private IPlateau _plateau;
        private List<IPositionCheck> _positionChecks;
        private List<IRover> _rovers = new List<IRover>();

        public List<IRover> Rovers
        {
            get { return this._rovers; }
            private set { this._rovers = value; }
        }

        public List<IPositionCheck> PositionChecks
        {
            set { this._positionChecks = value; }
        }
        
        public PlateauController(IPlateau plateau)
        {
            this._plateau = plateau;
        }

        /// <summary>
        /// Places rover on plateau and process instructions
        /// </summary>
        /// <param name="rover"></param>
        /// <param name="instructions"></param>
        public void ProcessRover(IRover rover)
        {
            rover.OnRoverMoved += new RoverMoveEventHandler(rover_OnRoverMoved);
            this.Rovers.Add(rover);
            CheckPositions(rover);
            rover.Instruction.Execute(rover);
        }

        private void rover_OnRoverMoved(object sender, RoverEventArgs e)
        {
            CheckPositions(e.Rover);
        }

        public void CheckPositions(IRover rover)
        {
            foreach (IPositionCheck positionCheck in this._positionChecks)
            {
                positionCheck.MovedRover = rover;
                positionCheck.ExistingRovers = this._rovers;
                positionCheck.Plateau = this._plateau;
                positionCheck.Check();
            }
        }
    }
}