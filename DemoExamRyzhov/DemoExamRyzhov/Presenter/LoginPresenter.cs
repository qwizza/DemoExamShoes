using DemoExamRyzhov.Model;
using DemoExamRyzhov.View;
using System;

namespace DemoExamRyzhov.Presenter
{
    public class LoginPresenter
    {
        // Поля класса
        private readonly ILoginView _view;
        private readonly AuthRepository _repository;

        // Конструктор
        public LoginPresenter(ILoginView view, AuthRepository repository)
        {
            _view = view;
            _repository = repository;

            _view.LoginClicked += OnLoginClicked;
            _view.GuestClicked += OnGuestClicked;
        }

        // Обработчик событий авторизации
        private void OnLoginClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.LoginText) || string.IsNullOrWhiteSpace(_view.PasswordText))
            {
                _view.ShowMessage("Заполните логин и пароль!");
                return;
            }

            var result = _repository.ValidateUser(_view.LoginText, _view.PasswordText);

            if (result.isSuccess)
            {
                UserSession.FullName = result.fullName;
                UserSession.UserId = result.userId;

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
        // Сессия для гостя
        private void OnGuestClicked(object sender, EventArgs e)
        {
            UserSession.CurrentRole = UserRole.Guest;
            UserSession.FullName = "Гость";
            UserSession.UserId = null;

            _view.CloseView();
        }
    }
}