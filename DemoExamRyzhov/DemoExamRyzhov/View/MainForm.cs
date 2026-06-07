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
    public partial class MainForm : Form, IMainView
    {
        public string SearchText => txtSearch.Text;
        public string SelectedCategory => cmbCategory.SelectedItem?.ToString();
        public string SelectedManufacturer => cmbManufacturer.SelectedItem?.ToString();
        public string SelectedSort => cmbSort.SelectedItem?.ToString();

        // Реализация всех событий интерфейса
        public event EventHandler FilterChanged;
        public event EventHandler AddProductClicked;
        public event EventHandler EditProductClicked;
        public event EventHandler DeleteProductClicked;

        public event EventHandler AddOrderClicked;
        public event EventHandler EditOrderClicked;
        public event EventHandler DeleteOrderClicked;

        public event EventHandler AddPointClicked;
        public event EventHandler EditPointClicked;
        public event EventHandler DeletePointClicked;

        public event EventHandler AddUserClicked;
        public event EventHandler EditUserClicked;
        public event EventHandler DeleteUserClicked;

        public MainForm()
        {
            InitializeComponent();
            ApplyStyleGuide();

            // Обработчики фильтров
            txtSearch.TextChanged += (s, e) => FilterChanged?.Invoke(this, EventArgs.Empty);
            cmbCategory.SelectedIndexChanged += (s, e) => FilterChanged?.Invoke(this, EventArgs.Empty);
            cmbManufacturer.SelectedIndexChanged += (s, e) => FilterChanged?.Invoke(this, EventArgs.Empty);
            cmbSort.SelectedIndexChanged += (s, e) => FilterChanged?.Invoke(this, EventArgs.Empty);

            // Обработчики Кнопок ТОВАРОВ
            btnAddProduct.Click += (s, e) => AddProductClicked?.Invoke(this, EventArgs.Empty);
            btnEditProduct.Click += (s, e) => EditProductClicked?.Invoke(this, EventArgs.Empty);
            btnDeleteProduct.Click += (s, e) => DeleteProductClicked?.Invoke(this, EventArgs.Empty);

            // Обработчики Кнопок ЗАКАЗОВ
            btnAddOrder.Click += (s, e) => AddOrderClicked?.Invoke(this, EventArgs.Empty);
            btnEditOrder.Click += (s, e) => EditOrderClicked?.Invoke(this, EventArgs.Empty);
            btnDeleteOrder.Click += (s, e) => DeleteOrderClicked?.Invoke(this, EventArgs.Empty);

            // Обработчики Кнопок ПУНКТОВ ВЫДАЧИ
            btnAddPoint.Click += (s, e) => AddPointClicked?.Invoke(this, EventArgs.Empty);
            btnEditPoint.Click += (s, e) => EditPointClicked?.Invoke(this, EventArgs.Empty);
            btnDeletePoint.Click += (s, e) => DeletePointClicked?.Invoke(this, EventArgs.Empty);

            // Обработчики Кнопок ПОЛЬЗОВАТЕЛЕЙ
            btnAddUser.Click += (s, e) => AddUserClicked?.Invoke(this, EventArgs.Empty);
            btnEditUser.Click += (s, e) => EditUserClicked?.Invoke(this, EventArgs.Empty);
            btnDeleteUser.Click += (s, e) => DeleteUserClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ApplyStyleGuide()
        {
            this.Text = "Главное окно системы — ООО «Обувь»";
            this.Font = new Font("Times New Roman", 11f);
            this.BackColor = Color.White;

            if (panelHeader == null || btnAddProduct == null || cmbSort == null)
                return;

            panelHeader.BackColor = ColorTranslator.FromHtml("#7FFF00");

            // Красим ВСЕ целевые кнопки "Добавить" в цвет #00FA9A и задаем плоский стиль
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

        public void ApplyAccessRights(UserRole role)
        {
            // По умолчанию включаем отображение фильтров (для тех, кому они нужны)
            panelFilters.Visible = true;

            // 1. ГОСТЬ и АВТОРИЗОВАННЫЙ ПОЛЬЗОВАТЕЛЬ (КЛИЕНТ)
            if (role == UserRole.Guest || role == UserRole.Client)
            {
                // Отключаем фильтры (если гостю они не нужны, как было в твоем коде)
                panelFilters.Visible = false;

                // Прячем абсолютно все панели с кнопками Добавить/Удалить/Изменить
                panelCRUDProducts.Visible = false;
                panelCRUDOrders.Visible = false;
                panelCRUDPoints.Visible = false;
                panelCRUDUsers.Visible = false;

                // Удаляем все вкладки, кроме Товаров
                if (tabControl.TabPages.Contains(tabOrders)) tabControl.TabPages.Remove(tabOrders);
                if (tabControl.TabPages.Contains(tabPoints)) tabControl.TabPages.Remove(tabPoints);
                if (tabControl.TabPages.Contains(tabUsers)) tabControl.TabPages.Remove(tabUsers);
            }
            // 2. МЕНЕДЖЕР
            else if (role == UserRole.Manager)
            {
                // Менеджеру доступны кнопки управления для разрешенных вкладок
                panelCRUDProducts.Visible = true;
                panelCRUDOrders.Visible = true;
                panelCRUDPoints.Visible = true;

                // Панель кнопок пользователей прячем
                panelCRUDUsers.Visible = false;

                // Удаляем только вкладку Пользователи (Вкладка Пункты выдачи "tabPoints" ТЕПЕРЬ ОСТАЕТСЯ)
                if (tabControl.TabPages.Contains(tabUsers)) tabControl.TabPages.Remove(tabUsers);
            }
            // 3. АДМИНИСТРАТОР
            else if (role == UserRole.Admin)
            {
                // Администратору доступно абсолютно всё
                panelCRUDProducts.Visible = true;
                panelCRUDOrders.Visible = true;
                panelCRUDPoints.Visible = true;
                panelCRUDUsers.Visible = true;

                // Проверяем, чтобы вкладки были на месте (если форма пересоздается)
                // Если вкладки не удалялись динамически приложением ранее, этот блок сработает по умолчанию
            }
        }

        public void FillFilterComboboxes(List<string> categories, List<string> manufacturers)
        {
            cmbCategory.DataSource = categories;
            cmbManufacturer.DataSource = manufacturers;
        }

        public void SetProducts(DataTable dt)
        {
            dgvProducts.DataSource = dt;

            // Переименовываем столбцы для пользователя, но для C# имена остаются прежними
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

            HighlightDiscounts(); // Твой метод подсветки сработает идеально, т.к. Cells["discount"] остался на английском
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
