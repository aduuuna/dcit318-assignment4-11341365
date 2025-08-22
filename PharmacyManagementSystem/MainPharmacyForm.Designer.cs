using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PharmacyManagementSystem
{
    partial class MainPharmacyForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtMedicineName;
        private TextBox txtCategory;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private TextBox txtSearch;
        private Button btnAddMedicine;
        private Button btnSearch;
        private Button btnUpdateStock;
        private Button btnRecordSale;
        private Button btnViewAll;
        private DataGridView dgvMedicines;
        private Label lblMedicineName;
        private Label lblCategory;
        private Label lblPrice;
        private Label lblQuantity;
        private Label lblSearch;
        private Label lblTitle;
        private Label lblSelectedMedicine;
        private GroupBox grpMedicineDetails;
        private GroupBox grpSearch;
        private GroupBox grpActions;
        private Button btnViewSalesReport;

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
            this.txtMedicineName = new TextBox();
            this.txtCategory = new TextBox();
            this.txtPrice = new TextBox();
            this.txtQuantity = new TextBox();
            this.txtSearch = new TextBox();
            this.btnAddMedicine = new Button();
            this.btnSearch = new Button();
            this.btnUpdateStock = new Button();
            this.btnRecordSale = new Button();
            this.btnViewAll = new Button();
            this.dgvMedicines = new DataGridView();
            this.lblMedicineName = new Label();
            this.lblCategory = new Label();
            this.lblPrice = new Label();
            this.lblQuantity = new Label();
            this.lblSearch = new Label();
            this.lblTitle = new Label();
            this.lblSelectedMedicine = new Label();
            this.grpMedicineDetails = new GroupBox();
            this.grpSearch = new GroupBox();
            this.grpActions = new GroupBox();
            this.btnViewSalesReport = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.grpMedicineDetails.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(300, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Pharmacy Management System";

            // grpMedicineDetails
            this.grpMedicineDetails.Controls.Add(this.lblMedicineName);
            this.grpMedicineDetails.Controls.Add(this.txtMedicineName);
            this.grpMedicineDetails.Controls.Add(this.lblCategory);
            this.grpMedicineDetails.Controls.Add(this.txtCategory);
            this.grpMedicineDetails.Controls.Add(this.lblPrice);
            this.grpMedicineDetails.Controls.Add(this.txtPrice);
            this.grpMedicineDetails.Controls.Add(this.lblQuantity);
            this.grpMedicineDetails.Controls.Add(this.txtQuantity);
            this.grpMedicineDetails.Location = new System.Drawing.Point(20, 60);
            this.grpMedicineDetails.Name = "grpMedicineDetails";
            this.grpMedicineDetails.Size = new System.Drawing.Size(300, 180);
            this.grpMedicineDetails.TabIndex = 1;
            this.grpMedicineDetails.TabStop = false;
            this.grpMedicineDetails.Text = "Medicine Details";

            // lblMedicineName
            this.lblMedicineName.AutoSize = true;
            this.lblMedicineName.Location = new System.Drawing.Point(15, 30);
            this.lblMedicineName.Name = "lblMedicineName";
            this.lblMedicineName.Size = new System.Drawing.Size(85, 13);
            this.lblMedicineName.TabIndex = 0;
            this.lblMedicineName.Text = "Medicine Name:";

            // txtMedicineName
            this.txtMedicineName.Location = new System.Drawing.Point(110, 27);
            this.txtMedicineName.Name = "txtMedicineName";
            this.txtMedicineName.Size = new System.Drawing.Size(170, 20);
            this.txtMedicineName.TabIndex = 1;

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(15, 65);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category:";

            // txtCategory
            this.txtCategory.Location = new System.Drawing.Point(110, 62);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(170, 20);
            this.txtCategory.TabIndex = 3;

            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(15, 100);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Price:";

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(110, 97);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(170, 20);
            this.txtPrice.TabIndex = 5;

            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(15, 135);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 6;
            this.lblQuantity.Text = "Quantity:";

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(110, 132);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(170, 20);
            this.txtQuantity.TabIndex = 7;

            // grpSearch
            this.grpSearch.Controls.Add(this.lblSearch);
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.btnViewAll);
            this.grpSearch.Location = new System.Drawing.Point(340, 60);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(300, 90);
            this.grpSearch.TabIndex = 2;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search";

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(15, 30);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(65, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(150, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(220, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnViewAll
            this.btnViewAll.Location = new System.Drawing.Point(15, 55);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(100, 25);
            this.btnViewAll.TabIndex = 3;
            this.btnViewAll.Text = "View All";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);

            // grpActions
            this.grpActions.Controls.Add(this.btnAddMedicine);
            this.grpActions.Controls.Add(this.btnUpdateStock);
            this.grpActions.Controls.Add(this.btnRecordSale);
            this.grpActions.Controls.Add(this.btnViewSalesReport);
            this.grpActions.Location = new System.Drawing.Point(660, 60);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(150, 220);
            this.grpActions.TabIndex = 3;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Actions";

            // btnAddMedicine
            this.btnAddMedicine.Location = new System.Drawing.Point(15, 30);
            this.btnAddMedicine.Name = "btnAddMedicine";
            this.btnAddMedicine.Size = new System.Drawing.Size(120, 35);
            this.btnAddMedicine.TabIndex = 0;
            this.btnAddMedicine.Text = "Add Medicine";
            this.btnAddMedicine.UseVisualStyleBackColor = true;
            this.btnAddMedicine.Click += new System.EventHandler(this.btnAddMedicine_Click);

            // btnUpdateStock
            this.btnUpdateStock.Location = new System.Drawing.Point(15, 80);
            this.btnUpdateStock.Name = "btnUpdateStock";
            this.btnUpdateStock.Size = new System.Drawing.Size(120, 35);
            this.btnUpdateStock.TabIndex = 1;
            this.btnUpdateStock.Text = "Update Stock";
            this.btnUpdateStock.UseVisualStyleBackColor = true;
            this.btnUpdateStock.Click += new System.EventHandler(this.btnUpdateStock_Click);

            // btnRecordSale
            this.btnRecordSale.Location = new System.Drawing.Point(15, 130);
            this.btnRecordSale.Name = "btnRecordSale";
            this.btnRecordSale.Size = new System.Drawing.Size(120, 35);
            this.btnRecordSale.TabIndex = 2;
            this.btnRecordSale.Text = "Record Sale";
            this.btnRecordSale.UseVisualStyleBackColor = true;
            this.btnRecordSale.Click += new System.EventHandler(this.btnRecordSale_Click);

            // btnViewSalesReport
            this.btnViewSalesReport.Location = new System.Drawing.Point(15, 180);
            this.btnViewSalesReport.Name = "btnViewSalesReport";
            this.btnViewSalesReport.Size = new System.Drawing.Size(120, 35);
            this.btnViewSalesReport.TabIndex = 3;
            this.btnViewSalesReport.Text = "Sales Report";
            this.btnViewSalesReport.UseVisualStyleBackColor = true;
            this.btnViewSalesReport.Click += new System.EventHandler(this.btnViewSalesReport_Click);

            // dgvMedicines
            this.dgvMedicines.AllowUserToAddRows = false;
            this.dgvMedicines.AllowUserToDeleteRows = false;
            this.dgvMedicines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicines.Location = new System.Drawing.Point(20, 270);
            this.dgvMedicines.MultiSelect = false;
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.ReadOnly = true;
            this.dgvMedicines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicines.Size = new System.Drawing.Size(790, 280);
            this.dgvMedicines.TabIndex = 4;
            this.dgvMedicines.SelectionChanged += new System.EventHandler(this.dgvMedicines_SelectionChanged);

            // lblSelectedMedicine
            this.lblSelectedMedicine.AutoSize = true;
            this.lblSelectedMedicine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.lblSelectedMedicine.Location = new System.Drawing.Point(20, 250);
            this.lblSelectedMedicine.Name = "lblSelectedMedicine";
            this.lblSelectedMedicine.Size = new System.Drawing.Size(120, 15);
            this.lblSelectedMedicine.TabIndex = 5;
            this.lblSelectedMedicine.Text = "Selected: None";

            // MainPharmacyForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 570);
            this.Controls.Add(this.lblSelectedMedicine);
            this.Controls.Add(this.dgvMedicines);
            this.Controls.Add(this.grpActions);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpMedicineDetails);
            this.Controls.Add(this.lblTitle);
            this.Name = "MainPharmacyForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pharmacy Management System";
            this.Load += new System.EventHandler(this.MainPharmacyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.grpMedicineDetails.ResumeLayout(false);
            this.grpMedicineDetails.PerformLayout();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void MainPharmacyForm_Load(object sender, EventArgs e)
        {
            // Form load event - can be used for initialization
        }
    }
}