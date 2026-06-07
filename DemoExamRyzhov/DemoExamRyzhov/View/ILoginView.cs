using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExamRyzhov.View
{
    public interface ILoginView
    {
        // Свойства для презентора
        string LoginText { get; }
        string PasswordText { get; }

        // События
        event EventHandler LoginClicked;
        event EventHandler GuestClicked;

        // Методы управления окном
        void ShowMessage(string message);
        void CloseView();
    }
}
