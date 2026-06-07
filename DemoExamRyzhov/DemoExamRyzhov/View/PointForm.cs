using System;
using System.Windows.Forms;

namespace DemoExamRyzhov.View
{
    public partial class PointForm : Form
    {
        // свойства
        public string AddressText => txtAddress.Text;
        private int? _pointId = null;

        // Конструктор для добавления
        public PointForm()
        {
            InitializeComponent();
            this.Text = "Добавить пункт выдачи";
            btnSave.Text = "Добавить";
        }

        // Конструктор для редактирования
        public PointForm(int id, string currentAddress) : this()
        {
            _pointId = id;
            txtAddress.Text = currentAddress;
            this.Text = "Редактировать пункт выдачи";
            btnSave.Text = "Сохранить";
        }

        // обработчик событий
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Адрес не может быть пустым!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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