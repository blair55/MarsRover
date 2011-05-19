using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;
using MarsRover.Core.Factories;

namespace MarsRover.Core
{
    public class FactoryFacade
    {
        public static IRover GetRover(string s)
        {
            return RoverFactory.GetRover(s);
        }

        public static IPlateau GetPlateau(string s)
        {
            return PlateauFactory.GetPlateau(s);
        }
        
        public static IInstruction GetInstruction(string s)
        {
            return InstructionFactory.GetCompositeInstruction(s);
        }

        public static List<IPositionCheck> GetPositionChecks()
        {
            return PositionCheckFactory.GetPositionChecks();
        }
    }
}