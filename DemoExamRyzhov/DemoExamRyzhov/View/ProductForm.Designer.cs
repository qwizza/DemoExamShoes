namespace DemoExamRyzhov.View
{
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.TableLayoutPanel mainLayout;
            System.Windows.Forms.FlowLayoutPanel buttonLayout;
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            System.Windows.Forms.Label lbl1 = new System.Windows.Forms.Label() { Text = "Артикул:", Font = new System.Drawing.Font("Segoe UI", 9F) };
            System.Windows.Forms.Label lbl2 = new System.Windows.Forms.Label() { Text = "Наименование:", Font = new System.Drawing.Font("Segoe UI", 9F) };
            System.Windows.Forms.Label lbl3 = new System.Windows.Forms.Label() { Text = "Ед. измерения:", Font = new System.Drawing.Font("Segoe UI", 9F) };
            System.Windows.Forms.Label lbl4 = new System.Windows.Forms.Label() { Text = "Цена:", Font = new System.Drawing.Font("Segoe UI", 9F) };
            System.Windows.Forms.Label lbl5 = new System.Windows.Forms.Label() { Text = "Поставщик:", Font = new System.Drawing.Font("Segoe UI", 9F) };
            System.Windows.Forms.Label lbl6 = new System.Windows.Forms.Label() { Text = "Производитель:", Font = new System.Drawing.Font("Segoe UI", 9F) };
            System.Windows.Forms.Label lbl7 = new System.Windows.Forms.Label() { Text = "Категория:", Font = new System.Drawing.Font("Segoe UI", 9F) };
            System.Windows.Forms.Label lbl8 = new System.Windows.Forms.Label() { Text = "Скидка (%):", Font = new System.Drawing.Font("Segoe UI", 9F) };
            System.Windows.Forms.Label lbl9 = new System.Windows.Forms.Label() { Text = "Кол-во на складе:", Font = new System.Drawing.Font("Segoe UI", 9F) };
            System.Windows.Forms.Label lbl10 = new System.Windows.Forms.Label() { Text = "Описание:", Font = new System.Drawing.Font("Segoe UI", 9F) };

            mainLayout = new System.Windows.Forms.TableLayoutPanel();
            buttonLayout = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            mainLayout.SuspendLayout();
            buttonLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

            mainLayout.Controls.Add(lbl1, 0, 0); mainLayout.Controls.Add(this.txtArticle, 0, 1);
            mainLayout.Controls.Add(lbl2, 1, 0); mainLayout.Controls.Add(this.txtName, 1, 1);

            mainLayout.Controls.Add(lbl3, 0, 2); mainLayout.Controls.Add(this.txtUnit, 0, 3);
            mainLayout.Controls.Add(lbl4, 1, 2); mainLayout.Controls.Add(this.numPrice, 1, 3);

            mainLayout.Controls.Add(lbl5, 0, 4); mainLayout.Controls.Add(this.txtSupplier, 0, 5);
            mainLayout.Controls.Add(lbl6, 1, 4); mainLayout.Controls.Add(this.cmbManufacturer, 1, 5);

            mainLayout.Controls.Add(lbl7, 0, 6); mainLayout.Controls.Add(this.cmbCategory, 0, 7);
            mainLayout.Controls.Add(lbl8, 1, 6); mainLayout.Controls.Add(this.numDiscount, 1, 7);

            mainLayout.Controls.Add(lbl9, 0, 8); mainLayout.Controls.Add(this.numStock, 0, 9);
            mainLayout.Controls.Add(lbl10, 0, 10); mainLayout.SetColumnSpan(lbl10, 2);
            mainLayout.Controls.Add(this.txtDescription, 0, 11); mainLayout.SetColumnSpan(this.txtDescription, 2);

            mainLayout.Controls.Add(buttonLayout, 0, 12); mainLayout.SetColumnSpan(buttonLayout, 2);

            mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            mainLayout.Location = new System.Drawing.Point(15, 15);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 13;
            for (int i = 0; i < 12; i++) mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainLayout.Size = new System.Drawing.Size(454, 451);
            // 
            // Контролы ввода данных
            // 
            this.txtArticle.Dock = System.Windows.Forms.DockStyle.Fill; this.txtArticle.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill; this.txtName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.txtUnit.Dock = System.Windows.Forms.DockStyle.Fill; this.txtUnit.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.numPrice.Dock = System.Windows.Forms.DockStyle.Fill; this.numPrice.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10); this.numPrice.Maximum = 1000000;
            this.txtSupplier.Dock = System.Windows.Forms.DockStyle.Fill; this.txtSupplier.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.cmbManufacturer.Dock = System.Windows.Forms.DockStyle.Fill; this.cmbManufacturer.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10); this.cmbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Dock = System.Windows.Forms.DockStyle.Fill; this.cmbCategory.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10); this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numDiscount.Dock = System.Windows.Forms.DockStyle.Fill; this.numDiscount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.numStock.Dock = System.Windows.Forms.DockStyle.Fill; this.numStock.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10); this.numStock.Maximum = 10000;
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill; this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15); this.txtDescription.Multiline = true; this.txtDescription.Height = 60;
            // 
            // buttonLayout
            // 
            buttonLayout.Controls.Add(this.btnCancel);
            buttonLayout.Controls.Add(this.btnSave);
            buttonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            buttonLayout.Size = new System.Drawing.Size(448, 40);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Size = new System.Drawing.Size(100, 30); this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ProductForm
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(484, 481);
            this.Controls.Add(mainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            buttonLayout.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox txtArticle;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.ComboBox cmbManufacturer;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}