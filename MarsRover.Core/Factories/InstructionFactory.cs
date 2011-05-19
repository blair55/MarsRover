using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Objects.Instructions;
using MarsRover.Interfaces;

namespace MarsRover.Core.Factories
{
    public static class InstructionFactory
    {
        internal static IInstruction GetCompositeInstruction(string s)
        {
            var compsiteInstruction = new CompositeInstruction();

            foreach (char c in s.ToCharArray())
                compsiteInstruction.AddInstruction(GetInstruction(c));

            return compsiteInstruction;
        }

        private static IInstruction GetInstruction(char c)
        {
            switch (c)
            {
                case 'l':
                    return new TurnLeftInstruction();
                case 'r':
                    return new TurnRightInstruction();
                case 'm':
                    return new MoveInstruction();
                default:
                    throw new InvalidCastException("Could not interpret Instruction: " + c);
            }
        }
    }
}