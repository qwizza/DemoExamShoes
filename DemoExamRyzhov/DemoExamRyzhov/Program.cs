using DemoExamRyzhov.Model;
using DemoExamRyzhov.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoExamRyzhov
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Создаем сущности авторизации
            LoginForm loginForm = new LoginForm();
            AuthRepository authRepo = new AuthRepository();

            // Связываем их через презентер
            LoginPresenter presenter = new LoginPresenter(loginForm, authRepo);

            // Если форма закрылась с результатом OK (вход выполнен успешно или как гость)
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Создаем элементы главного окна
                MainForm mainForm = new MainForm();
                MainRepository mainRepo = new MainRepository();

                // Связываем форму и репозиторий через презентер главного окна
                MainPresenter mainPresenter = new MainPresenter(mainForm, mainRepo);

                // Запускаем главное окно программы
                Application.Run(mainForm);
            }
        }
    }
}
