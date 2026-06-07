using DemoExamRyzhov.Model;
using DemoExamRyzhov.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DemoExamRyzhov
{
    public partial class MainForm : Form, IMainView
    {
        // Поля фильтрации и поиска
        public string SearchText => txtSearch.Text;
        public string SelectedCategory => cmbCategory.SelectedItem?.ToString();
        public string SelectedManufacturer => cmbManufacturer.SelectedItem?.ToString();
        public string SelectedSort => cmbSort.SelectedItem?.ToString();

        // События интерфейса
        public event EventHandler FilterChanged;

        // Товары
        public event EventHandler AddProductClicked;
        public event EventHandler EditProductClicked;
        public event EventHandler DeleteProductClicked;

        // Заказы
        public event EventHandler AddOrderClicked;
        public event EventHandler EditOrderClicked;
        public event EventHandler DeleteOrderClicked;

        // ПВЗ
        public event EventHandler AddPointClicked;
        public event EventHandler EditPointClicked;
        public event EventHandler DeletePointClicked;

        // Пользователи
        public event EventHandler AddUserClicked;
        public event EventHandler EditUserClicked;
        public event EventHandler DeleteUserClicked;

        // конструктор и события 
        public MainForm()
        {
            InitializeComponent();
            ApplyStyleGuide();

            // Обработчики фильтров
            txtSearch.TextChanged += (s, e) => FilterChanged?.Invoke(this, EventArgs.Empty);
            cmbCategory.SelectedIndexChanged += (s, e) => FilterChanged?.Invoke(this, EventArgs.Empty);
            cmbManufacturer.SelectedIndexChanged += (s, e) => FilterChanged?.Invoke(this, EventArgs.Empty);
            cmbSort.SelectedIndexChanged += (s, e) => FilterChanged?.Invoke(this, EventArgs.Empty);

            // Обработчики кнопок товаров
            btnAddProduct.Click += (s, e) => AddProductClicked?.Invoke(this, EventArgs.Empty);
            btnEditProduct.Click += (s, e) => EditProductClicked?.Invoke(this, EventArgs.Empty);
            btnDeleteProduct.Click += (s, e) => DeleteProductClicked?.Invoke(this, EventArgs.Empty);

            // Обработчики кнопок заказов
            btnAddOrder.Click += (s, e) => AddOrderClicked?.Invoke(this, EventArgs.Empty);
            btnEditOrder.Click += (s, e) => EditOrderClicked?.Invoke(this, EventArgs.Empty);
            btnDeleteOrder.Click += (s, e) => DeleteOrderClicked?.Invoke(this, EventArgs.Empty);

            // Обработчики кнопок пвз
            btnAddPoint.Click += (s, e) => AddPointClicked?.Invoke(this, EventArgs.Empty);
            btnEditPoint.Click += (s, e) => EditPointClicked?.Invoke(this, EventArgs.Empty);
            btnDeletePoint.Click += (s, e) => DeletePointClicked?.Invoke(this, EventArgs.Empty);

            // Обработчики Кнопок пользователей
            btnAddUser.Click += (s, e) => AddUserClicked?.Invoke(this, EventArgs.Empty);
            btnEditUser.Click += (s, e) => EditUserClicked?.Invoke(this, EventArgs.Empty);
            btnDeleteUser.Click += (s, e) => DeleteUserClicked?.Invoke(this, EventArgs.Empty);
        }

        // Оформление по тз 
        private void ApplyStyleGuide()
        {
            this.Text = "Главное окно системы — ООО «Обувь»";
            this.Font = new Font("Times New Roman", 11f);
            this.BackColor = Color.White;

            if (panelHeader == null || btnAddProduct == null || cmbSort == null)
                return;

            panelHeader.BackColor = ColorTranslator.FromHtml("#7FFF00");

            Color targetColor = ColorTranslator.FromHtml("#00FA9A");

            btnAddProduct.BackColor = targetColor; btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnEditProduct.FlatStyle = FlatStyle.Flat; btnDeleteProduct.FlatStyle = FlatStyle.Flat;

            btnAddOrder.BackColor = targetColor; btnAddOrder.FlatStyle = FlatStyle.Flat;
            btnEditOrder.FlatStyle = FlatStyle.Flat; btnDeleteOrder.FlatStyle = FlatStyle.Flat;

            btnAddPoint.BackColor = targetColor; btnAddPoint.FlatStyle = FlatStyle.Flat;
            btnEditPoint.FlatStyle = FlatStyle.Flat; btnDeletePoint.FlatStyle = FlatStyle.Flat;

            btnAddUser.BackColor = targetColor; btnAddUser.FlatStyle = FlatStyle.Flat;
            btnEditUser.FlatStyle = FlatStyle.Flat; btnDeleteUser.FlatStyle = FlatStyle.Flat;

            cmbSort.SelectedIndex = 0;

            if (pictureBoxLogo != null)
            {
                pictureBoxLogo.Image = Properties.Resources.Icon.ToBitmap();
                pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }

            this.WindowState = FormWindowState.Maximized;
        }

        // Ограничение прав по ролчм
        public void ApplyAccessRights(UserRole role)
        {
            panelFilters.Visible = true;

            // для готя и авторизованного пользователя
            if (role == UserRole.Guest || role == UserRole.Client)
            {
                panelFilters.Visible = false;

                panelCRUDProducts.Visible = false;
                panelCRUDOrders.Visible = false;
                panelCRUDPoints.Visible = false;
                panelCRUDUsers.Visible = false;

                if (tabControl.TabPages.Contains(tabOrders)) tabControl.TabPages.Remove(tabOrders);
                if (tabControl.TabPages.Contains(tabPoints)) tabControl.TabPages.Remove(tabPoints);
                if (tabControl.TabPages.Contains(tabUsers)) tabControl.TabPages.Remove(tabUsers);
            }
            // для менеджера
            else if (role == UserRole.Manager)
            {
                panelCRUDProducts.Visible = true;
                panelCRUDOrders.Visible = true;
                panelCRUDPoints.Visible = true;
                panelCRUDUsers.Visible = false;

                if (tabControl.TabPages.Contains(tabUsers)) tabControl.TabPages.Remove(tabUsers);
            }
            // для админа
            else if (role == UserRole.Admin)
            {
                panelCRUDProducts.Visible = true;
                panelCRUDOrders.Visible = true;
                panelCRUDPoints.Visible = true;
                panelCRUDUsers.Visible = true;
            }
        }

        // Метод заполнения данных и интерфейса с переводом названи столбцов
        public void FillFilterComboboxes(List<string> categories, List<string> manufacturers)
        {
            cmbCategory.DataSource = categories;
            cmbManufacturer.DataSource = manufacturers;
        }

        public void SetProducts(DataTable dt)
        {
            dgvProducts.DataSource = dt;

            if (dgvProducts.Columns["article"] != null) dgvProducts.Columns["article"].HeaderText = "Артикул";
            if (dgvProducts.Columns["name"] != null) dgvProducts.Columns["name"].HeaderText = "Наименование";
            if (dgvProducts.Columns["unit"] != null) dgvProducts.Columns["unit"].HeaderText = "Ед. измерения";
            if (dgvProducts.Columns["price"] != null) dgvProducts.Columns["price"].HeaderText = "Цена";
            if (dgvProducts.Columns["supplier"] != null) dgvProducts.Columns["supplier"].HeaderText = "Поставщик";
            if (dgvProducts.Columns["manufacturer"] != null) dgvProducts.Columns["manufacturer"].HeaderText = "Производитель";
            if (dgvProducts.Columns["category"] != null) dgvProducts.Columns["category"].HeaderText = "Категория";
            if (dgvProducts.Columns["discount"] != null) dgvProducts.Columns["discount"].HeaderText = "Скидка (%)";
            if (dgvProducts.Columns["stock"] != null) dgvProducts.Columns["stock"].HeaderText = "Кол-во на складе";
            if (dgvProducts.Columns["description"] != null) dgvProducts.Columns["description"].HeaderText = "Описание";

            HighlightDiscounts();
        }

        public void SetOrders(DataTable dt)
        {
            dgvOrders.DataSource = dt;

            if (dgvOrders.Columns["order_number"] != null) dgvOrders.Columns["order_number"].HeaderText = "Номер заказа";
            if (dgvOrders.Columns["order_date"] != null) dgvOrders.Columns["order_date"].HeaderText = "Дата заказа";
            if (dgvOrders.Columns["delivery_date"] != null) dgvOrders.Columns["delivery_date"].HeaderText = "Дата доставки";
            if (dgvOrders.Columns["order_point_address"] != null) dgvOrders.Columns["order_point_address"].HeaderText = "Адрес ПВЗ";
            if (dgvOrders.Columns["client"] != null) dgvOrders.Columns["client"].HeaderText = "Клиент";
            if (dgvOrders.Columns["status"] != null) dgvOrders.Columns["status"].HeaderText = "Статус";
        }

        public void SetDeliveryPoints(DataTable dt)
        {
            dgvPoints.DataSource = dt;

            if (dgvPoints.Columns["id"] != null) dgvPoints.Columns["id"].HeaderText = "ID";
            if (dgvPoints.Columns["address"] != null) dgvPoints.Columns["address"].HeaderText = "Адрес пункта";
        }

        public void SetUsers(DataTable dt)
        {
            dgvUsers.DataSource = dt;

            if (dgvUsers.Columns["id"] != null) dgvUsers.Columns["id"].HeaderText = "ID";
            if (dgvUsers.Columns["full_name"] != null) dgvUsers.Columns["full_name"].HeaderText = "ФИО";
            if (dgvUsers.Columns["login"] != null) dgvUsers.Columns["login"].HeaderText = "Логин";
            if (dgvUsers.Columns["role_name"] != null) dgvUsers.Columns["role_name"].HeaderText = "Роль";
        }

        public void ShowMessage(string message) => MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Подстветка строк при скидке больше 15
        private void HighlightDiscounts()
        {
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.Cells["discount"].Value != null && row.Cells["discount"].Value != DBNull.Value)
                {
                    int discount = Convert.ToInt32(row.Cells["discount"].Value);
                    if (discount > 15)
                    {
                        row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2E8B57");
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }
    }
}