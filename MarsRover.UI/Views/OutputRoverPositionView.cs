using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;

namespace MarsRover.UI.Views
{
    public class OutputRoverPositionView : IView
    {
        private int _index;
        private IRover _rover;

        public OutputRoverPositionView(int index, IRover rover)
        {
            this._index = index;
            this._rover = rover;
        }

        public string PromptMessage
        {
            get
            {
                return "Rover " + this._index + " End Position:"
                    + Environment.NewLine + this._rover.GetPositionOutput();
            }
        }

        public void Show()
        {
            Console.WriteLine(PromptMessage);
        }
    }
}