using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.UI.Views
{
    public class ErrorView : IView
    {
        private string _errorMessage;

        public string PromptMessage
        {
            get { return "An error was encountered: {0}"; }
        }

        public ErrorView(string errorMessage)
        {
            this._errorMessage = errorMessage;
        }

        public void Show()
        {
            Console.WriteLine(String.Format(this.PromptMessage, this._errorMessage));
        }
    }
}
