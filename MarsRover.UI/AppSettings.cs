using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MarsRover.UI
{
    public static class AppSettings
    {
        public static int GetRoverCount()
        {
            int roverCount;

            if (!int.TryParse(ConfigurationManager.AppSettings["RoverCount"], out roverCount))
                throw new FormatException("Rover count setting not a valid integer");

            return roverCount;
        }
    }
}
