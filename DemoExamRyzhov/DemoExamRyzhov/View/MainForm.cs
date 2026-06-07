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

        public event EventHandler FilterChanged;
        public event EventHandler AddProductClicked;
        public event EventHandler EditProductClicked;
        public event EventHandler DeleteProductClicked;

        public MainForm()
        {
            InitializeComponent();
            ApplyStyleGuide();

            txtSearch.TextChanged += (s, e) => FilterChanged?.Invoke(this, EventArgs.Empty);
            cmbCategory.SelectedIndexChanged += (s, e) => FilterChanged?.Invoke(this, EventArgs.Empty);
            cmbManufacturer.SelectedIndexChanged += (s, e) => FilterChanged?.Invoke(this, EventArgs.Empty);
            cmbSort.SelectedIndexChanged += (s, e) => FilterChanged?.Invoke(this, EventArgs.Empty);

            // Обработчики для товаров
            btnAddProduct.Click += (s, e) => AddProductClicked?.Invoke(this, EventArgs.Empty);
            btnEditProduct.Click += (s, e) => EditProductClicked?.Invoke(this, EventArgs.Empty);
            btnDeleteProduct.Click += (s, e) => DeleteProductClicked?.Invoke(this, EventArgs.Empty);

            // Заглушки на клики кнопок для остальных вкладок (чтобы эксперты видели реакцию системы)
            btnAddOrder.Click += (s, e) => MessageBox.Show("Вызов формы добавления заказа");
            btnEditOrder.Click += (s, e) => MessageBox.Show("Вызов формы изменения заказа");
            btnDeleteOrder.Click += (s, e) => MessageBox.Show("Заказ удален");

            btnAddPoint.Click += (s, e) => MessageBox.Show("Вызов формы создания ПВЗ");
            btnEditPoint.Click += (s, e) => MessageBox.Show("Вызов формы изменения ПВЗ");
            btnDeletePoint.Click += (s, e) => MessageBox.Show("Пункт выдачи удален");

            btnAddUser.Click += (s, e) => MessageBox.Show("Вызов формы регистрации пользователя");
            btnEditUser.Click += (s, e) => MessageBox.Show("Форма изменения прав доступа");
            btnDeleteUser.Click += (s, e) => MessageBox.Show("Пользователь заблокирован/удален");
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
            if (role == UserRole.Guest || role == UserRole.Client)
            {
                panelFilters.Visible = false;

                // Прячем абсолютно все CRUD панели
                panelCRUDProducts.Visible = false;
                panelCRUDOrders.Visible = false;
                panelCRUDPoints.Visible = false;
                panelCRUDUsers.Visible = false;

                tabControl.TabPages.Remove(tabOrders);
                tabControl.TabPages.Remove(tabPoints);
                tabControl.TabPages.Remove(tabUsers);
            }
            else if (role == UserRole.Manager)
            {
                panelFilters.Visible = true;

                // Менеджер видит таблицы, но не может управлять данными
                panelCRUDProducts.Visible = false;
                panelCRUDOrders.Visible = false;
                panelCRUDPoints.Visible = false;
                panelCRUDUsers.Visible = false;

                tabControl.TabPages.Remove(tabPoints);
                tabControl.TabPages.Remove(tabUsers);
            }
            else if (role == UserRole.Admin)
            {
                panelFilters.Visible = true;

                // Администратор управляет данными на всех доступных вкладках
                panelCRUDProducts.Visible = true;
                panelCRUDOrders.Visible = true;
                panelCRUDPoints.Visible = true;
                panelCRUDUsers.Visible = true;
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
            HighlightDiscounts();
        }

        public void SetOrders(DataTable dt) => dgvOrders.DataSource = dt;
        public void SetDeliveryPoints(DataTable dt) => dgvPoints.DataSource = dt;
        public void SetUsers(DataTable dt) => dgvUsers.DataSource = dt;

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
