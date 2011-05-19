using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using MarsRover.Interfaces;

namespace MarsRover.Objects.Instructions
{
    public class CompositeInstruction : IInstruction
    {
        private List<IInstruction> _instructions = new List<IInstruction>();

#if DEBUG
        public IInstruction this[int i]
        {
            get { return this._instructions[i]; }
        }
#endif

        public void AddInstruction(IInstruction instruction)
        {
            _instructions.Add(instruction);
        }

        public void Execute(IRover rover)
        {
            foreach (IInstruction instruction in _instructions)
                instruction.Execute(rover);
        }
    }
}