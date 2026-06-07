using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DemoExamRyzhov.View
{
    public partial class ProductForm : Form
    {
        // свойства для презентора
        public string ArticleText => txtArticle.Text;
        public string NameText => txtName.Text;
        public string UnitText => txtUnit.Text;
        public decimal PriceValue => numPrice.Value;
        public string SupplierText => txtSupplier.Text;
        public string SelectedManufacturer => cmbManufacturer.SelectedItem?.ToString();
        public string SelectedCategory => cmbCategory.SelectedItem?.ToString();
        public int DiscountValue => (int)numDiscount.Value;
        public int StockValue => (int)numStock.Value;
        public string DescriptionText => txtDescription.Text;

        private bool _isEditMode = false;

        // Конструктор для добавления
        public ProductForm(List<string> categories, List<string> manufacturers)
        {
            InitializeComponent();
            LoadLists(categories, manufacturers);

            this.Text = "Добавить новый товар";
            btnSave.Text = "Добавить";
            _isEditMode = false;
        }

        // Конструктор для редактирования
        public ProductForm(DataRow row, List<string> categories, List<string> manufacturers)
            : this(categories, manufacturers)
        {
            _isEditMode = true;
            txtArticle.ReadOnly = true;

            // Заполнения полей старыми данными
            txtArticle.Text = row["article"].ToString();
            txtName.Text = row["name"].ToString();
            txtUnit.Text = row["unit"].ToString();
            numPrice.Value = Convert.ToDecimal(row["price"]);
            txtSupplier.Text = row["supplier"].ToString();
            cmbManufacturer.SelectedItem = row["manufacturer"].ToString();
            cmbCategory.SelectedItem = row["category"].ToString();
            numDiscount.Value = Convert.ToInt32(row["discount"]);
            numStock.Value = Convert.ToInt32(row["stock"]);
            txtDescription.Text = row["description"].ToString();

            this.Text = "Редактировать товар";
            btnSave.Text = "Сохранить";
        }

        // Метод загрузки
        private void LoadLists(List<string> categories, List<string> manufacturers)
        {
            cmbCategory.Items.Clear();
            cmbManufacturer.Items.Clear();

            foreach (var cat in categories)
                if (cat != "Все категории") cmbCategory.Items.Add(cat);

            foreach (var man in manufacturers)
                if (man != "Все производители") cmbManufacturer.Items.Add(man);

            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            if (cmbManufacturer.Items.Count > 0) cmbManufacturer.SelectedIndex = 0;
        }

        // Обработчик событий
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArticle.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Артикул и Название товара обязательны для заполнения!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
