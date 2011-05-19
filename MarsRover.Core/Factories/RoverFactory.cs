using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;
using MarsRover.Objects;

namespace MarsRover.Core.Factories
{
    public class RoverFactory
    {
        /// <summary>
        /// Returns Rover.
        /// Will throw exception on invalid user input.
        /// </summary>
        /// <returns></returns>
        internal static IRover GetRover(string s)
        {
            string[] array = GetValidArray(s);
            return GetRoverFromArray(array);
        }

        private static string[] GetValidArray(string s)
        {
            string[] array = s.Split(' ');

            if (array.Length != 3)
                throw new ArgumentOutOfRangeException("Incorrect number of arguments for Rover");

            return array;
        }

        private static IRover GetRoverFromArray(string[] array)
        {
            IRover rover;

            try
            {
                int x = Convert.ToInt32(array[0]);
                int y = Convert.ToInt32(array[1]);
                CardinalType c = (CardinalType)Enum.Parse(typeof(CardinalType), (array[2]).ToUpper());
                rover = new Rover { X = x, Y = y, Cardinal = c };
            }
            catch (Exception e)
            {
                throw new InvalidCastException("Could not interpret Rover input");
            }

            return rover;
        }
    }
}