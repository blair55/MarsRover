using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Interfaces;
using MarsRover.Core;

namespace MarsRover.UI.Views
{
    public class GetInstructionView : IView
    {
        private int _index;
        public IInstruction Instruction { get; private set; }

        public GetInstructionView(int index)
        {
            this._index = index;
        }

        public string PromptMessage
        {
            get { return "Please enter Rover " + this._index + " instructions [l/r/m]"; }
        }

        public void Show()
        {
            Console.WriteLine(PromptMessage);
            this.Instruction = FactoryFacade.GetInstruction(Console.ReadLine());
        }
    }
}
