using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;
using MarsRover.Core;

namespace MarsRover.UI.Views
{
    public class GetRoverView : IView
    {
        private int _index;
        public IRover Rover { get; private set; }

        public GetRoverView(int index)
        {
            this._index = index;
        }

        public string PromptMessage
        {
            get { return "Please enter Rover " + this._index + " position [x y cardinal]"; }
        }

        public void Show()
        {
            Console.WriteLine(PromptMessage);
            this.Rover = FactoryFacade.GetRover(Console.ReadLine());
        }
    }
}
