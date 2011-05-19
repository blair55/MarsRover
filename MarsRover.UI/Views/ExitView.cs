using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.UI.Views
{
    public class ExitView : IView
    {
        public string PromptMessage
        {
            get { return "Press enter to exit"; }
        }

        public void Show()
        {
            Console.WriteLine(PromptMessage);
            Console.ReadLine();
        }
    }
}
