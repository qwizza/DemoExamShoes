using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExamRyzhov.View
{
    public interface ILoginView
    {
        // Пропсы (свойства), чтобы презентер мог забрать текст из полей ввода
        string LoginText { get; }
        string PasswordText { get; }

        // События, на которые презентер будет подписываться
        event EventHandler LoginClicked;
        event EventHandler GuestClicked;

        // Методы управления окном
        void ShowMessage(string message);
        void CloseView();
    }
}
