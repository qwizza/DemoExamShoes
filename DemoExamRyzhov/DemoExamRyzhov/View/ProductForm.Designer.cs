using System.Windows.Forms;

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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lbl5 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lbl6 = new System.Windows.Forms.Label();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.lbl7 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lbl8 = new System.Windows.Forms.Label();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.lbl9 = new System.Windows.Forms.Label();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.lbl10 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.buttonLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.mainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            this.buttonLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.Controls.Add(this.lbl1, 0, 0);
            this.mainLayout.Controls.Add(this.txtArticle, 0, 1);
            this.mainLayout.Controls.Add(this.lbl2, 1, 0);
            this.mainLayout.Controls.Add(this.txtName, 1, 1);
            this.mainLayout.Controls.Add(this.lbl3, 0, 2);
            this.mainLayout.Controls.Add(this.txtUnit, 0, 3);
            this.mainLayout.Controls.Add(this.lbl4, 1, 2);
            this.mainLayout.Controls.Add(this.numPrice, 1, 3);
            this.mainLayout.Controls.Add(this.lbl5, 0, 4);
            this.mainLayout.Controls.Add(this.txtSupplier, 0, 5);
            this.mainLayout.Controls.Add(this.lbl6, 1, 4);
            this.mainLayout.Controls.Add(this.cmbManufacturer, 1, 5);
            this.mainLayout.Controls.Add(this.lbl7, 0, 6);
            this.mainLayout.Controls.Add(this.cmbCategory, 0, 7);
            this.mainLayout.Controls.Add(this.lbl8, 1, 6);
            this.mainLayout.Controls.Add(this.numDiscount, 1, 7);
            this.mainLayout.Controls.Add(this.lbl9, 0, 8);
            this.mainLayout.Controls.Add(this.numStock, 0, 9);
            this.mainLayout.Controls.Add(this.lbl10, 0, 10);
            this.mainLayout.Controls.Add(this.txtDescription, 0, 11);
            this.mainLayout.Controls.Add(this.buttonLayout, 0, 12);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(15, 15);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 13;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(454, 451);
            this.mainLayout.TabIndex = 0;
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(3, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(100, 23);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Артикул:";
            // 
            // txtArticle
            // 
            this.txtArticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtArticle.Location = new System.Drawing.Point(3, 26);
            this.txtArticle.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.txtArticle.Name = "txtArticle";
            this.txtArticle.Size = new System.Drawing.Size(221, 22);
            this.txtArticle.TabIndex = 1;
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(230, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(100, 23);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "Наименование:";
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(230, 26);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(221, 22);
            this.txtName.TabIndex = 3;
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(3, 58);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(100, 23);
            this.lbl3.TabIndex = 4;
            this.lbl3.Text = "Ед. измерения:";
            // 
            // txtUnit
            // 
            this.txtUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnit.Location = new System.Drawing.Point(3, 84);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(221, 22);
            this.txtUnit.TabIndex = 5;
            // 
            // lbl4
            // 
            this.lbl4.Location = new System.Drawing.Point(230, 58);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(100, 23);
            this.lbl4.TabIndex = 6;
            this.lbl4.Text = "Цена:";
            // 
            // numPrice
            // 
            this.numPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numPrice.Location = new System.Drawing.Point(230, 84);
            this.numPrice.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.numPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(221, 22);
            this.numPrice.TabIndex = 7;
            // 
            // lbl5
            // 
            this.lbl5.Location = new System.Drawing.Point(3, 116);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(100, 23);
            this.lbl5.TabIndex = 8;
            this.lbl5.Text = "Поставщик:";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSupplier.Location = new System.Drawing.Point(3, 142);
            this.txtSupplier.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(221, 22);
            this.txtSupplier.TabIndex = 9;
            // 
            // lbl6
            // 
            this.lbl6.Location = new System.Drawing.Point(230, 116);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(100, 23);
            this.lbl6.TabIndex = 10;
            this.lbl6.Text = "Производитель:";
            // 
            // cmbManufacturer
            // 
            this.cmbManufacturer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManufacturer.Location = new System.Drawing.Point(230, 142);
            this.cmbManufacturer.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.cmbManufacturer.Name = "cmbManufacturer";
            this.cmbManufacturer.Size = new System.Drawing.Size(221, 24);
            this.cmbManufacturer.TabIndex = 11;
            // 
            // lbl7
            // 
            this.lbl7.Location = new System.Drawing.Point(3, 176);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(100, 23);
            this.lbl7.TabIndex = 12;
            this.lbl7.Text = "Категория:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(3, 202);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(221, 24);
            this.cmbCategory.TabIndex = 13;
            // 
            // lbl8
            // 
            this.lbl8.Location = new System.Drawing.Point(230, 176);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(100, 23);
            this.lbl8.TabIndex = 14;
            this.lbl8.Text = "Скидка (%):";
            // 
            // numDiscount
            // 
            this.numDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numDiscount.Location = new System.Drawing.Point(230, 202);
            this.numDiscount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(221, 22);
            this.numDiscount.TabIndex = 15;
            // 
            // lbl9
            // 
            this.lbl9.Location = new System.Drawing.Point(3, 236);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(100, 23);
            this.lbl9.TabIndex = 16;
            this.lbl9.Text = "Кол-во на складе:";
            // 
            // numStock
            // 
            this.numStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numStock.Location = new System.Drawing.Point(3, 262);
            this.numStock.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.numStock.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(221, 22);
            this.numStock.TabIndex = 17;
            // 
            // lbl10
            // 
            this.mainLayout.SetColumnSpan(this.lbl10, 2);
            this.lbl10.Location = new System.Drawing.Point(3, 294);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(100, 23);
            this.lbl10.TabIndex = 18;
            this.lbl10.Text = "Описание:";
            // 
            // txtDescription
            // 
            this.mainLayout.SetColumnSpan(this.txtDescription, 2);
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(3, 320);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(448, 60);
            this.txtDescription.TabIndex = 19;
            // 
            // buttonLayout
            // 
            this.mainLayout.SetColumnSpan(this.buttonLayout, 2);
            this.buttonLayout.Controls.Add(this.btnCancel);
            this.buttonLayout.Controls.Add(this.btnSave);
            this.buttonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonLayout.Location = new System.Drawing.Point(3, 398);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.Size = new System.Drawing.Size(448, 50);
            this.buttonLayout.TabIndex = 20;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(345, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(239, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ProductForm
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(484, 481);
            this.Controls.Add(this.mainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductForm";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            this.buttonLayout.ResumeLayout(false);
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
        private TableLayoutPanel mainLayout;
        private Label lbl1;
        private Label lbl2;
        private Label lbl3;
        private Label lbl4;
        private Label lbl5;
        private Label lbl6;
        private Label lbl7;
        private Label lbl8;
        private Label lbl9;
        private Label lbl10;
        private FlowLayoutPanel buttonLayout;
    }
}