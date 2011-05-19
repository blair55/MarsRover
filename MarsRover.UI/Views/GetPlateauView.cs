using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;
using MarsRover.Core;

namespace MarsRover.UI.Views
{
    public class GetPlateauView : IView
    {
        public IPlateau Plateau { get; private set; }

        public string PromptMessage
        {
            get { return "Please enter Plateau size [x y]"; }
        }

        public void Show()
        {
            Console.WriteLine(PromptMessage);
            this.Plateau = FactoryFacade.GetPlateau(Console.ReadLine());
        }
    }
}
