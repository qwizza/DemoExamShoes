using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoExamRyzhov.View
{
    public partial class UserForm : Form
    {
        public string FullNameText => txtFullName.Text;
        public string LoginText => txtLogin.Text;
        public string SelectedRole => cmbRole.SelectedItem?.ToString();

        private int? _userId = null;

        // Конструктор для ДОБАВЛЕНИЯ
        public UserForm(List<string> roles)
        {
            InitializeComponent();
            LoadRoles(roles);
            this.Text = "Добавить пользователя";
            btnSave.Text = "Добавить";
        }

        // Конструктор для РЕДАКТИРОВАНИЯ
        public UserForm(int id, string fullName, string login, string currentRole, List<string> roles) : this(roles)
        {
            _userId = id;
            txtFullName.Text = fullName;
            txtLogin.Text = login;
            cmbRole.SelectedItem = currentRole;
            this.Text = "Редактировать пользователя";
            btnSave.Text = "Сохранить";
        }

        private void LoadRoles(List<string> roles)
        {
            cmbRole.Items.Clear();
            foreach (var role in roles)
            {
                cmbRole.Items.Add(role);
            }
            if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Заполните ФИО и Логин!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
