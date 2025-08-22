using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MedicalAppointmentSystem
{
    partial class DoctorListForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvDoctors;
        private TextBox txtSearch;
        private ComboBox cmbSpecialty;
        private Label lblSearch;
        private Label lblSpecialty;

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
            this.dgvDoctors = new DataGridView();
            this.txtSearch = new TextBox();
            this.cmbSpecialty = new ComboBox();
            this.lblSearch = new Label();
            this.lblSpecialty = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).BeginInit();
            this.SuspendLayout();

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(75, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search Name:";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(93, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // lblSpecialty
            this.lblSpecialty.AutoSize = true;
            this.lblSpecialty.Location = new System.Drawing.Point(320, 15);
            this.lblSpecialty.Name = "lblSpecialty";
            this.lblSpecialty.Size = new System.Drawing.Size(55, 13);
            this.lblSpecialty.TabIndex = 2;
            this.lblSpecialty.Text = "Specialty:";

            // cmbSpecialty
            this.cmbSpecialty.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSpecialty.Location = new System.Drawing.Point(381, 12);
            this.cmbSpecialty.Name = "cmbSpecialty";
            this.cmbSpecialty.Size = new System.Drawing.Size(150, 21);
            this.cmbSpecialty.TabIndex = 3;
            this.cmbSpecialty.SelectedIndexChanged += new System.EventHandler(this.cmbSpecialty_SelectedIndexChanged);

            // dgvDoctors
            this.dgvDoctors.AllowUserToAddRows = false;
            this.dgvDoctors.AllowUserToDeleteRows = false;
            this.dgvDoctors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoctors.Location = new System.Drawing.Point(12, 50);
            this.dgvDoctors.Name = "dgvDoctors";
            this.dgvDoctors.ReadOnly = true;
            this.dgvDoctors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoctors.Size = new System.Drawing.Size(560, 300);
            this.dgvDoctors.TabIndex = 4;

            // DoctorListForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.dgvDoctors);
            this.Controls.Add(this.cmbSpecialty);
            this.Controls.Add(this.lblSpecialty);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "DoctorListForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Doctor List";
            this.Load += new System.EventHandler(this.DoctorListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}