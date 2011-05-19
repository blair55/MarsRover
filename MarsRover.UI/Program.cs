using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Core;
using MarsRover.UI.Views;
using MarsRover.Interfaces;

namespace MarsRover.UI
{
    class Program
    {
        static PlateauController PlateauController { get; set; }
        static int RoverCount { get; set; }

        static void Main(string[] args)
        {
            try
            {
                Initialize();
                GetRoversAndProcessInstructions();
                OutputRoverPositions();
            }
            catch (Exception e)
            {
                DisplayError(e.Message);
            }
            finally
            {
                Exit();
            }
        }

        private static void Initialize()
        {
            RoverCount = AppSettings.GetRoverCount();
            PlateauController = new PlateauController(GetPlateau());
            PlateauController.PositionChecks = FactoryFacade.GetPositionChecks();
        }

        private static IPlateau GetPlateau()
        {
            var getPlateauView = new GetPlateauView();
            getPlateauView.Show();
            return getPlateauView.Plateau;
        }

        private static void GetRoversAndProcessInstructions()
        {
            for (int i = 1; i <= RoverCount; i++)
            {
                var getRoverView = new GetRoverView(i);
                getRoverView.Show();

                var getInstructionView = new GetInstructionView(i);
                getInstructionView.Show();

                IRover rover = getRoverView.Rover;
                rover.Instruction = getInstructionView.Instruction;

                PlateauController.ProcessRover(rover);
            }
        }

        private static void OutputRoverPositions()
        {
            foreach (var container in PlateauController.Rovers.Select((r, i) => new { Rover = r, Index = i + 1 }))
                new OutputRoverPositionView(container.Index, container.Rover).Show();
        }

        private static void DisplayError(string errorMessage)
        {
            new ErrorView(errorMessage).Show();
        }

        private static void Exit()
        {
            new ExitView().Show();
        }
    }
}