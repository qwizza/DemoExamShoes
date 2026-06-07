using DemoExamRyzhov.Model;
using DemoExamRyzhov.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExamRyzhov.Presenter
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly AuthRepository _repository;

        public LoginPresenter(ILoginView view, AuthRepository repository)
        {
            _view = view;
            _repository = repository;

            // Подписываемся на события формы
            _view.LoginClicked += OnLoginClicked;
            _view.GuestClicked += OnGuestClicked;
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            // Проверяем, что поля не пустые
            if (string.IsNullOrWhiteSpace(_view.LoginText) || string.IsNullOrWhiteSpace(_view.PasswordText))
            {
                _view.ShowMessage("Заполните логин и пароль!");
                return;
            }

            // Идём в базу данных через репозиторий
            var result = _repository.ValidateUser(_view.LoginText, _view.PasswordText);

            if (result.isSuccess)
            {
                // Записываем данные в глобальную сессию
                UserSession.FullName = result.fullName;
                UserSession.UserId = result.userId;

                // Превращаем текстовую роль из БД в наш Enum
                if (result.roleName == "Администратор") UserSession.CurrentRole = UserRole.Admin;
                else if (result.roleName == "Менеджер") UserSession.CurrentRole = UserRole.Manager;
                else UserSession.CurrentRole = UserRole.Client;

                _view.ShowMessage($"Успешный вход! Добро пожаловать, {UserSession.FullName} ({result.roleName}).");
                _view.CloseView();
            }
            else
            {
                _view.ShowMessage("Неверный логин или пароль!");
            }
        }

        private void OnGuestClicked(object sender, EventArgs e)
        {
            // Настраиваем сессию под гостя
            UserSession.CurrentRole = UserRole.Guest;
            UserSession.FullName = "Гость";
            UserSession.UserId = null;

            _view.CloseView();
        }
    }
}
