using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyManagementSystem
{
    partial class SalesReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvSales;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnFilterByDate;
        private Button btnRefresh;
        private Button btnClose;
        private Label lblStartDate;
        private Label lblEndDate;
        private Label lblTitle;
        private Label lblTotalSales;
        private Label lblTotalQuantity;
        private Label lblTotalRecords;
        private GroupBox grpDateFilter;
        private GroupBox grpSummary;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvSales = new DataGridView();
            this.dtpStartDate = new DateTimePicker();
            this.dtpEndDate = new DateTimePicker();
            this.btnFilterByDate = new Button();
            this.btnRefresh = new Button();
            this.btnClose = new Button();
            this.lblStartDate = new Label();
            this.lblEndDate = new Label();
            this.lblTitle = new Label();
            this.lblTotalSales = new Label();
            this.lblTotalQuantity = new Label();
            this.lblTotalRecords = new Label();
            this.grpDateFilter = new GroupBox();
            this.grpSummary = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.grpDateFilter.SuspendLayout();
            this.grpSummary.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(300, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Sales Report";

            // grpDateFilter
            this.grpDateFilter.Controls.Add(this.lblStartDate);
            this.grpDateFilter.Controls.Add(this.dtpStartDate);
            this.grpDateFilter.Controls.Add(this.lblEndDate);
            this.grpDateFilter.Controls.Add(this.dtpEndDate);
            this.grpDateFilter.Controls.Add(this.btnFilterByDate);
            this.grpDateFilter.Location = new System.Drawing.Point(20, 50);
            this.grpDateFilter.Name = "grpDateFilter";
            this.grpDateFilter.Size = new System.Drawing.Size(500, 80);
            this.grpDateFilter.TabIndex = 1;
            this.grpDateFilter.TabStop = false;
            this.grpDateFilter.Text = "Date Filter";

            // lblStartDate
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(15, 30);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(58, 13);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start Date:";

            // dtpStartDate
            this.dtpStartDate.Format = DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(80, 27);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(100, 20);
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.Value = DateTime.Now.AddDays(-30);

            // lblEndDate
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(200, 30);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(55, 13);
            this.lblEndDate.TabIndex = 2;
            this.lblEndDate.Text = "End Date:";

            // dtpEndDate
            this.dtpEndDate.Format = DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(260, 27);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(100, 20);
            this.dtpEndDate.TabIndex = 3;
            this.dtpEndDate.Value = DateTime.Now;

            // btnFilterByDate
            this.btnFilterByDate.Location = new System.Drawing.Point(380, 25);
            this.btnFilterByDate.Name = "btnFilterByDate";
            this.btnFilterByDate.Size = new System.Drawing.Size(100, 25);
            this.btnFilterByDate.TabIndex = 4;
            this.btnFilterByDate.Text = "Filter by Date";
            this.btnFilterByDate.UseVisualStyleBackColor = true;
            this.btnFilterByDate.Click += new System.EventHandler(this.btnFilterByDate_Click);

            // grpSummary
            this.grpSummary.Controls.Add(this.lblTotalSales);
            this.grpSummary.Controls.Add(this.lblTotalQuantity);
            this.grpSummary.Controls.Add(this.lblTotalRecords);
            this.grpSummary.Location = new System.Drawing.Point(540, 50);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(200, 80);
            this.grpSummary.TabIndex = 2;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Summary";

            // lblTotalSales
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Location = new System.Drawing.Point(15, 20);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(72, 13);
            this.lblTotalSales.TabIndex = 0;
            this.lblTotalSales.Text = "Total Sales: ₦0.00";

            // lblTotalQuantity
            this.lblTotalQuantity.AutoSize = true;
            this.lblTotalQuantity.Location = new System.Drawing.Point(15, 40);
            this.lblTotalQuantity.Name = "lblTotalQuantity";
            this.lblTotalQuantity.Size = new System.Drawing.Size(110, 13);
            this.lblTotalQuantity.TabIndex = 1;
            this.lblTotalQuantity.Text = "Total Quantity Sold: 0";

            // lblTotalRecords
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Location = new System.Drawing.Point(15, 60);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(85, 13);
            this.lblTotalRecords.TabIndex = 2;
            this.lblTotalRecords.Text = "Total Records: 0";

            // dgvSales
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.AllowUserToDeleteRows = false;
            this.dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSales.Location = new System.Drawing.Point(20, 150);
            this.dgvSales.MultiSelect = false;
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.ReadOnly = true;
            this.dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.Size = new System.Drawing.Size(720, 300);
            this.dgvSales.TabIndex = 3;

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(520, 470);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(640, 470);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // SalesReportForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 520);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvSales);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.grpDateFilter);
            this.Controls.Add(this.lblTitle);
            this.Name = "SalesReportForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Sales Report";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.grpDateFilter.ResumeLayout(false);
            this.grpDateFilter.PerformLayout();
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}