using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MedicalAppointmentSystem
{
    partial class ManageAppointmentsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvAppointments;
        private DateTimePicker dtpNewDate;
        private TextBox txtNewNotes;
        private Button btnUpdate;
        private Button btnDelete;
        private Label lblNewDate;
        private Label lblNewNotes;
        private Label lblTitle;

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
            this.dgvAppointments = new DataGridView();
            this.dtpNewDate = new DateTimePicker();
            this.txtNewNotes = new TextBox();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.lblNewDate = new Label();
            this.lblNewNotes = new Label();
            this.lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(170, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Appointments";

            // dgvAppointments
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.Location = new System.Drawing.Point(12, 40);
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(700, 250);
            this.dgvAppointments.TabIndex = 1;
            this.dgvAppointments.SelectionChanged += new System.EventHandler(this.dgvAppointments_SelectionChanged);

            // lblNewDate
            this.lblNewDate.AutoSize = true;
            this.lblNewDate.Location = new System.Drawing.Point(12, 310);
            this.lblNewDate.Name = "lblNewDate";
            this.lblNewDate.Size = new System.Drawing.Size(61, 13);
            this.lblNewDate.TabIndex = 2;
            this.lblNewDate.Text = "New Date:";

            // dtpNewDate
            this.dtpNewDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNewDate.Format = DateTimePickerFormat.Custom;
            this.dtpNewDate.Location = new System.Drawing.Point(79, 307);
            this.dtpNewDate.Name = "dtpNewDate";
            this.dtpNewDate.ShowUpDown = true;
            this.dtpNewDate.Size = new System.Drawing.Size(200, 20);
            this.dtpNewDate.TabIndex = 3;

            // lblNewNotes
            this.lblNewNotes.AutoSize = true;
            this.lblNewNotes.Location = new System.Drawing.Point(300, 310);
            this.lblNewNotes.Name = "lblNewNotes";
            this.lblNewNotes.Size = new System.Drawing.Size(66, 13);
            this.lblNewNotes.TabIndex = 4;
            this.lblNewNotes.Text = "New Notes:";

            // txtNewNotes
            this.txtNewNotes.Location = new System.Drawing.Point(372, 307);
            this.txtNewNotes.Multiline = true;
            this.txtNewNotes.Name = "txtNewNotes";
            this.txtNewNotes.Size = new System.Drawing.Size(200, 60);
            this.txtNewNotes.TabIndex = 5;

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(590, 307);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(590, 343);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // ManageAppointmentsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 385);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtNewNotes);
            this.Controls.Add(this.lblNewNotes);
            this.Controls.Add(this.dtpNewDate);
            this.Controls.Add(this.lblNewDate);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.lblTitle);
            this.Name = "ManageAppointmentsForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Manage Appointments";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}