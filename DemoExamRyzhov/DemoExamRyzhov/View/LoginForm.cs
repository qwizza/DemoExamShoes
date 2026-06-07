using DemoExamRyzhov.Model;
using DemoExamRyzhov.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoExamRyzhov
{
    public partial class LoginForm : Form, ILoginView
    {
        // Реализуем свойства интерфейса (берём текст из текстбоксов)
        public string LoginText => txtLogin.Text;
        public string PasswordText => txtPassword.Text;

        // Реализуем события интерфейса
        public event EventHandler LoginClicked;
        public event EventHandler GuestClicked;

        public LoginForm()
        {
            InitializeComponent();
            ApplyStyleGuide();

            // Привязываем клики по кнопкам к событиям интерфейса
            btnLogin.Click += (s, e) => LoginClicked?.Invoke(this, EventArgs.Empty);
            btnGuest.Click += (s, e) => GuestClicked?.Invoke(this, EventArgs.Empty);
        }

        // Применяем требования из брендбука задания
        private void ApplyStyleGuide()
        {
            this.Text = "Авторизация — ООО «Обувь»"; // Заголовок формы по ТЗ
            this.Font = new Font("Times New Roman", 11f); // Шрифт по ТЗ
            this.BackColor = Color.White; // Основной фон белый

            // Кнопка "Войти" — это целевое действие, красим в #00FA9A
            btnLogin.BackColor = ColorTranslator.FromHtml("#00FA9A");
            btnLogin.FlatStyle = FlatStyle.Flat;

            // Кнопка "Войти как гость" — дополнительный фон #7FFF00
            btnGuest.BackColor = ColorTranslator.FromHtml("#7FFF00");
            btnGuest.FlatStyle = FlatStyle.Flat;
        }

        // Реализуем методы интерфейса
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CloseView()
        {
            // Устанавливаем DialogResult.OK, чтобы Program.cs понял, что можно открывать MainForm
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
