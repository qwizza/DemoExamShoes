using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoExamRyzhov.View
{
    public partial class OrderForm : Form
    {
        public string SelectedPoint => cmbPoint.SelectedItem?.ToString();
        public string SelectedClient => cmbClient.SelectedItem?.ToString();
        public string SelectedStatus => cmbStatus.SelectedItem?.ToString();
        public DateTime OrderDateValue => dtpDate.Value;
        public DateTime DeliveryDateValue => dtpDeliveryDate.Value;

        private int? _orderNumber = null;

        // Конструктор для ДОБАВЛЕНИЯ
        public OrderForm(List<string> points, List<string> clients, List<string> statuses)
        {
            InitializeComponent();
            LoadData(points, clients, statuses);
            dtpDeliveryDate.Value = DateTime.Now.AddDays(3); // Дефолтное значение
            this.Text = "Создать новый заказ";
            btnSave.Text = "Создать";
        }

        // Конструктор для РЕДАКТИРОВАНИЯ
        public OrderForm(int orderNumber, DateTime date, DateTime deliveryDate, string currentPoint, string currentClient, string currentStatus, List<string> points, List<string> clients, List<string> statuses)
            : this(points, clients, statuses)
        {
            _orderNumber = orderNumber;
            dtpDate.Value = date;
            dtpDeliveryDate.Value = deliveryDate;
            cmbPoint.SelectedItem = currentPoint;
            cmbClient.SelectedItem = currentClient;
            cmbStatus.SelectedItem = currentStatus;

            this.Text = $"Редактировать заказ №{orderNumber}";
            btnSave.Text = "Сохранить";
        }

        private void LoadData(List<string> points, List<string> clients, List<string> statuses)
        {
            cmbPoint.Items.Clear();
            cmbClient.Items.Clear();
            cmbStatus.Items.Clear();

            foreach (var point in points) cmbPoint.Items.Add(point);
            foreach (var client in clients) cmbClient.Items.Add(client);
            foreach (var status in statuses) cmbStatus.Items.Add(status);

            if (cmbPoint.Items.Count > 0) cmbPoint.SelectedIndex = 0;
            if (cmbClient.Items.Count > 0) cmbClient.SelectedIndex = 0;
            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbPoint.SelectedItem == null || cmbClient.SelectedItem == null || cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля заказа!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpDeliveryDate.Value < dtpDate.Value)
            {
                MessageBox.Show("Дата доставки не может быть раньше даты заказа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
