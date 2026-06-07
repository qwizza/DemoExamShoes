namespace DemoExamRyzhov
{
    partial class MainForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.panelCRUDProducts = new System.Windows.Forms.Panel();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.panelCRUDOrders = new System.Windows.Forms.Panel();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.tabPoints = new System.Windows.Forms.TabPage();
            this.dgvPoints = new System.Windows.Forms.DataGridView();
            this.panelCRUDPoints = new System.Windows.Forms.Panel();
            this.btnDeletePoint = new System.Windows.Forms.Button();
            this.btnEditPoint = new System.Windows.Forms.Button();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.panelCRUDUsers = new System.Windows.Forms.Panel();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.panelCRUDProducts.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.tabOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.panelCRUDOrders.SuspendLayout();
            this.tabPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).BeginInit();
            this.panelCRUDPoints.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panelCRUDUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(984, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(90, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(244, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Магазин ООО «Обувь»";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(12, 5);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabProducts);
            this.tabControl.Controls.Add(this.tabOrders);
            this.tabControl.Controls.Add(this.tabPoints);
            this.tabControl.Controls.Add(this.tabUsers);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 70);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(984, 591);
            this.tabControl.TabIndex = 1;
            // 
            // tabProducts
            // 
            this.tabProducts.Controls.Add(this.dgvProducts);
            this.tabProducts.Controls.Add(this.panelCRUDProducts);
            this.tabProducts.Controls.Add(this.panelFilters);
            this.tabProducts.Location = new System.Drawing.Point(4, 22);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(976, 565);
            this.tabProducts.TabIndex = 0;
            this.tabProducts.Text = "Товары";
            this.tabProducts.UseVisualStyleBackColor = true;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(3, 63);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.Size = new System.Drawing.Size(970, 444);
            this.dgvProducts.TabIndex = 1;
            // 
            // panelCRUDProducts
            // 
            this.panelCRUDProducts.Controls.Add(this.btnDeleteProduct);
            this.panelCRUDProducts.Controls.Add(this.btnEditProduct);
            this.panelCRUDProducts.Controls.Add(this.btnAddProduct);
            this.panelCRUDProducts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCRUDProducts.Location = new System.Drawing.Point(3, 507);
            this.panelCRUDProducts.Name = "panelCRUDProducts";
            this.panelCRUDProducts.Size = new System.Drawing.Size(970, 55);
            this.panelCRUDProducts.TabIndex = 2;
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(265, 10);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteProduct.TabIndex = 2;
            this.btnDeleteProduct.Text = "Удалить  товар ";
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Location = new System.Drawing.Point(139, 10);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(120, 35);
            this.btnEditProduct.TabIndex = 1;
            this.btnEditProduct.Text = "Редактировать  товар";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(13, 10);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(120, 35);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Добавить товар";
            // 
            // panelFilters
            // 
            this.panelFilters.Controls.Add(this.lblSort);
            this.panelFilters.Controls.Add(this.cmbSort);
            this.panelFilters.Controls.Add(this.lblManufacturer);
            this.panelFilters.Controls.Add(this.cmbManufacturer);
            this.panelFilters.Controls.Add(this.lblCategory);
            this.panelFilters.Controls.Add(this.cmbCategory);
            this.panelFilters.Controls.Add(this.lblSearch);
            this.panelFilters.Controls.Add(this.txtSearch);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(3, 3);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(970, 60);
            this.panelFilters.TabIndex = 0;
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(745, 12);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(70, 13);
            this.lblSort.TabIndex = 7;
            this.lblSort.Text = "Сортировка:";
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Items.AddRange(new object[] {
            "Без сортировки",
            "Стоимость (по возрастанию)",
            "Стоимость (по убыванию)"});
            this.cmbSort.Location = new System.Drawing.Point(748, 28);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(200, 21);
            this.cmbSort.TabIndex = 6;
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(510, 12);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(89, 13);
            this.lblManufacturer.TabIndex = 5;
            this.lblManufacturer.Text = "Производитель:";
            // 
            // cmbManufacturer
            // 
            this.cmbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManufacturer.Location = new System.Drawing.Point(513, 28);
            this.cmbManufacturer.Name = "cmbManufacturer";
            this.cmbManufacturer.Size = new System.Drawing.Size(200, 21);
            this.cmbManufacturer.TabIndex = 4;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(275, 12);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 13);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "Категория:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(278, 28);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 21);
            this.cmbCategory.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, 12);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Поиск:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(13, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(230, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.dgvOrders);
            this.tabOrders.Controls.Add(this.panelCRUDOrders);
            this.tabOrders.Location = new System.Drawing.Point(4, 22);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrders.Size = new System.Drawing.Size(976, 565);
            this.tabOrders.TabIndex = 1;
            this.tabOrders.Text = "Заказы";
            this.tabOrders.UseVisualStyleBackColor = true;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(3, 3);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.Size = new System.Drawing.Size(970, 504);
            this.dgvOrders.TabIndex = 0;
            // 
            // panelCRUDOrders
            // 
            this.panelCRUDOrders.Controls.Add(this.btnDeleteOrder);
            this.panelCRUDOrders.Controls.Add(this.btnEditOrder);
            this.panelCRUDOrders.Controls.Add(this.btnAddOrder);
            this.panelCRUDOrders.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCRUDOrders.Location = new System.Drawing.Point(3, 507);
            this.panelCRUDOrders.Name = "panelCRUDOrders";
            this.panelCRUDOrders.Size = new System.Drawing.Size(970, 55);
            this.panelCRUDOrders.TabIndex = 1;
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(265, 10);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteOrder.TabIndex = 0;
            this.btnDeleteOrder.Text = "Удалить заказ";
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.Location = new System.Drawing.Point(139, 10);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(120, 35);
            this.btnEditOrder.TabIndex = 1;
            this.btnEditOrder.Text = "Редактировать заказ";
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(13, 10);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(120, 35);
            this.btnAddOrder.TabIndex = 2;
            this.btnAddOrder.Text = "Создать заказ";
            // 
            // tabPoints
            // 
            this.tabPoints.Controls.Add(this.dgvPoints);
            this.tabPoints.Controls.Add(this.panelCRUDPoints);
            this.tabPoints.Location = new System.Drawing.Point(4, 22);
            this.tabPoints.Name = "tabPoints";
            this.tabPoints.Size = new System.Drawing.Size(976, 565);
            this.tabPoints.TabIndex = 2;
            this.tabPoints.Text = "Пункты выдачи";
            this.tabPoints.UseVisualStyleBackColor = true;
            // 
            // dgvPoints
            // 
            this.dgvPoints.AllowUserToAddRows = false;
            this.dgvPoints.AllowUserToDeleteRows = false;
            this.dgvPoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPoints.BackgroundColor = System.Drawing.Color.White;
            this.dgvPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPoints.Location = new System.Drawing.Point(0, 0);
            this.dgvPoints.Name = "dgvPoints";
            this.dgvPoints.ReadOnly = true;
            this.dgvPoints.Size = new System.Drawing.Size(976, 510);
            this.dgvPoints.TabIndex = 0;
            // 
            // panelCRUDPoints
            // 
            this.panelCRUDPoints.Controls.Add(this.btnDeletePoint);
            this.panelCRUDPoints.Controls.Add(this.btnEditPoint);
            this.panelCRUDPoints.Controls.Add(this.btnAddPoint);
            this.panelCRUDPoints.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCRUDPoints.Location = new System.Drawing.Point(0, 510);
            this.panelCRUDPoints.Name = "panelCRUDPoints";
            this.panelCRUDPoints.Size = new System.Drawing.Size(976, 55);
            this.panelCRUDPoints.TabIndex = 1;
            // 
            // btnDeletePoint
            // 
            this.btnDeletePoint.Location = new System.Drawing.Point(265, 10);
            this.btnDeletePoint.Name = "btnDeletePoint";
            this.btnDeletePoint.Size = new System.Drawing.Size(120, 35);
            this.btnDeletePoint.TabIndex = 0;
            this.btnDeletePoint.Text = "Удалить ПВЗ";
            // 
            // btnEditPoint
            // 
            this.btnEditPoint.Location = new System.Drawing.Point(139, 10);
            this.btnEditPoint.Name = "btnEditPoint";
            this.btnEditPoint.Size = new System.Drawing.Size(120, 35);
            this.btnEditPoint.TabIndex = 1;
            this.btnEditPoint.Text = "Изменить ПВЗ";
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Location = new System.Drawing.Point(13, 10);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(120, 35);
            this.btnAddPoint.TabIndex = 2;
            this.btnAddPoint.Text = "Добавить ПВЗ";
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.dgvUsers);
            this.tabUsers.Controls.Add(this.panelCRUDUsers);
            this.tabUsers.Location = new System.Drawing.Point(4, 22);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Size = new System.Drawing.Size(976, 565);
            this.tabUsers.TabIndex = 3;
            this.tabUsers.Text = "Пользователи";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(0, 0);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.Size = new System.Drawing.Size(976, 510);
            this.dgvUsers.TabIndex = 0;
            // 
            // panelCRUDUsers
            // 
            this.panelCRUDUsers.Controls.Add(this.btnDeleteUser);
            this.panelCRUDUsers.Controls.Add(this.btnEditUser);
            this.panelCRUDUsers.Controls.Add(this.btnAddUser);
            this.panelCRUDUsers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCRUDUsers.Location = new System.Drawing.Point(0, 510);
            this.panelCRUDUsers.Name = "panelCRUDUsers";
            this.panelCRUDUsers.Size = new System.Drawing.Size(976, 55);
            this.panelCRUDUsers.TabIndex = 1;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(265, 10);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteUser.TabIndex = 0;
            this.btnDeleteUser.Text = "Удалить пользователя";
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(139, 10);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(120, 35);
            this.btnEditUser.TabIndex = 1;
            this.btnEditUser.Text = "Изменить пользователя";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(13, 10);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(120, 35);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Создать пользователя";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelHeader);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.panelCRUDProducts.ResumeLayout(false);
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.tabOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.panelCRUDOrders.ResumeLayout(false);
            this.tabPoints.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).EndInit();
            this.panelCRUDPoints.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panelCRUDUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.TabPage tabPoints;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.ComboBox cmbManufacturer;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.DataGridView dgvProducts;

        private System.Windows.Forms.Panel panelCRUDProducts;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnAddProduct;

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Panel panelCRUDOrders;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnEditOrder;
        private System.Windows.Forms.Button btnAddOrder;

        private System.Windows.Forms.DataGridView dgvPoints;
        private System.Windows.Forms.Panel panelCRUDPoints;
        private System.Windows.Forms.Button btnDeletePoint;
        private System.Windows.Forms.Button btnEditPoint;
        private System.Windows.Forms.Button btnAddPoint;

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel panelCRUDUsers;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnAddUser;
    }
}