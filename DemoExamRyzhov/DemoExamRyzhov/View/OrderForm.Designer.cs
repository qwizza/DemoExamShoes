using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DemoExamRyzhov.View
{
    partial class OrderForm
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDeliveryDate = new System.Windows.Forms.Label(); // Новая лабель
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker(); // Новый календарь
            this.lblPoint = new System.Windows.Forms.Label();
            this.cmbPoint = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label(); // Новая лабель
            this.cmbClient = new System.Windows.Forms.ComboBox(); // Новый комбобокс
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.lblDate, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.dtpDate, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.lblDeliveryDate, 0, 2); // Дата доставки (л)
            this.tableLayoutPanel.Controls.Add(this.dtpDeliveryDate, 0, 3); // Дата доставки (к)
            this.tableLayoutPanel.Controls.Add(this.lblPoint, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.cmbPoint, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.lblClient, 0, 6); // Клиент (л)
            this.tableLayoutPanel.Controls.Add(this.cmbClient, 0, 7); // Клиент (к)
            this.tableLayoutPanel.Controls.Add(this.lblStatus, 0, 8);
            this.tableLayoutPanel.Controls.Add(this.cmbStatus, 0, 9);
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanel, 0, 10);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 11; // 11 строк под все элементы
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(354, 410);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDate.Location = new System.Drawing.Point(3, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(72, 15);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Дата заказа:";
            // 
            // dtpDate
            // 
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDate.Location = new System.Drawing.Point(3, 18);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(348, 23);
            this.dtpDate.TabIndex = 1;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDeliveryDate.Location = new System.Drawing.Point(3, 51);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(89, 15);
            this.lblDeliveryDate.TabIndex = 9;
            this.lblDeliveryDate.Text = "Дата доставки:";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDeliveryDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDeliveryDate.Location = new System.Drawing.Point(3, 69);
            this.dtpDeliveryDate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(348, 23);
            this.dtpDeliveryDate.TabIndex = 10;
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPoint.Location = new System.Drawing.Point(3, 102);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(87, 15);
            this.lblPoint.TabIndex = 2;
            this.lblPoint.Text = "Пункт выдачи:";
            // 
            // cmbPoint
            // 
            this.cmbPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPoint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPoint.Location = new System.Drawing.Point(3, 120);
            this.cmbPoint.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.cmbPoint.Name = "cmbPoint";
            this.cmbPoint.Size = new System.Drawing.Size(348, 23);
            this.cmbPoint.TabIndex = 3;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClient.Location = new System.Drawing.Point(3, 153);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(49, 15);
            this.lblClient.TabIndex = 7;
            this.lblClient.Text = "Клиент:";
            // 
            // cmbClient
            // 
            this.cmbClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbClient.Location = new System.Drawing.Point(3, 171);
            this.cmbClient.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(348, 23);
            this.cmbClient.TabIndex = 8;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(3, 204);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(83, 15);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Статус заказа:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStatus.Location = new System.Drawing.Point(3, 222);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(348, 23);
            this.cmbStatus.TabIndex = 5;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.btnCancel);
            this.flowLayoutPanel.Controls.Add(this.btnSave);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 268);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(348, 139);
            this.flowLayoutPanel.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.Location = new System.Drawing.Point(245, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.Location = new System.Drawing.Point(139, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // OrderForm
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 440); // Увеличена высота под новые поля
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderForm";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.flowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDeliveryDate; // Поле в дизайнере
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate; // Поле в дизайнере
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.ComboBox cmbPoint;
        private System.Windows.Forms.Label lblClient; // Поле в дизайнере
        private System.Windows.Forms.ComboBox cmbClient; // Поле в дизайнере
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}