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
    public partial class PointForm : Form
    {
        // Свойство для получения введенного адреса
        public string AddressText => txtAddress.Text;

        // Переменная, хранящая ID редактируемой записи (если null — значит это добавление)
        private int? _pointId = null;

        // Конструктор для ДОБАВЛЕНИЯ
        public PointForm()
        {
            InitializeComponent();
            this.Text = "Добавить пункт выдачи";
            btnSave.Text = "Добавить";
        }

        // Конструктор для РЕДАКТИРОВАНИЯ (принимает старые данные)
        public PointForm(int id, string currentAddress) : this()
        {
            _pointId = id;
            txtAddress.Text = currentAddress;
            this.Text = "Редактировать пункт выдачи";
            btnSave.Text = "Сохранить";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Адрес не может быть пустым!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Говорим главной форме, что всё прошло успешно, и закрываемся
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
