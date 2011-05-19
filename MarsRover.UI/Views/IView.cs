using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.UI.Views
{
    public interface IView
    {
        string PromptMessage { get; }
        void Show();
    }
}