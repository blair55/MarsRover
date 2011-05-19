using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;
using MarsRover.Interfaces.EventArguments;
using MarsRover.Objects.Instructions;

namespace MarsRover.Objects
{
    public class Rover : IRover
    {
        private string _id;
        private int _x;
        private int _y;
        private IInstruction _instruction = new NullInstruction();

        public event RoverMoveEventHandler OnRoverMoved;

        public string Id
        {
            get { return _id; }
        }

        public CardinalType Cardinal
        {
            get;
            set;
        }

        public IInstruction Instruction
        {
            get { return this._instruction; }
            set { this._instruction = value; }
        }

        public int X
        {
            get { return this._x; }
            set
            {
                this._x = value;
                
                if (this.OnRoverMoved != null)
                    this.OnRoverMoved(this, new RoverEventArgs(this));
            }
        }

        public int Y
        {
            get { return this._y; }
            set
            {
                this._y = value;

                if (this.OnRoverMoved != null)
                    this.OnRoverMoved(this, new RoverEventArgs(this));
            }
        }
        
        /// <summary>
        /// Id set on construction for plateau to identify each rover during collisions check
        /// </summary>
        public Rover()
        {
            this._id = Guid.NewGuid().ToString();
        }

        public string GetPositionOutput()
        {
            return this.X + " " + this.Y + " " + this.Cardinal.ToString();
        }

        public bool Equals(IRover rover)
        {
            return this.Id == rover.Id;
        }
    }
}