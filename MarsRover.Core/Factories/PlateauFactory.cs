using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;
using MarsRover.Objects;

namespace MarsRover.Core.Factories
{
    public class PlateauFactory
    {
        /// <summary>
        /// Returns Plateau.
        /// Will throw exception on invalid user input.
        /// </summary>
        /// <returns></returns>
        internal static IPlateau GetPlateau(string s)
        {
            string[] stringArray = GetPlateauStringArray(s);
            int[] plateauSize = GetPlateauSizeArray(stringArray);

            return new Plateau { Width = plateauSize[0], Height = plateauSize[1] };
        }

        private static string[] GetPlateauStringArray(string s)
        {
            string[] array = s.Split(' ');

            if (array.Length != 2)
                throw new ArgumentOutOfRangeException("Incorrect number of arguments for Plateau");

            return array;
        }

        private static int[] GetPlateauSizeArray(string[] s)
        {
            try
            {
                return Array.ConvertAll<string, int>(s, delegate(string p) { return int.Parse(p); });
            }
            catch (Exception e)
            {
                throw new InvalidCastException("Could not interpret Plateau dimensions");
            }
        }
    }
}