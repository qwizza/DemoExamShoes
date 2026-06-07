using DemoExamRyzhov.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DemoExamRyzhov
{
    public partial class LoginForm : Form, ILoginView
    {
        // Свойства интерфейса
        public string LoginText => txtLogin.Text;
        public string PasswordText => txtPassword.Text;

        // События
        public event EventHandler LoginClicked;
        public event EventHandler GuestClicked;

        // Конструктор
        public LoginForm()
        {
            InitializeComponent();
            ApplyStyleGuide();

            // Привязываем кнопки к событиям интерфейса
            btnLogin.Click += (s, e) => LoginClicked?.Invoke(this, EventArgs.Empty);
            btnGuest.Click += (s, e) => GuestClicked?.Invoke(this, EventArgs.Empty);
        }

        // Соформление по тз
        private void ApplyStyleGuide()
        {
            this.Text = "Авторизация — ООО «Обувь»"; 
            this.Font = new Font("Times New Roman", 11f); 
            this.BackColor = Color.White; 

            btnLogin.BackColor = ColorTranslator.FromHtml("#00FA9A");
            btnLogin.FlatStyle = FlatStyle.Flat;

            btnGuest.BackColor = ColorTranslator.FromHtml("#7FFF00");
            btnGuest.FlatStyle = FlatStyle.Flat;
        }

        // Методы
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CloseView()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}