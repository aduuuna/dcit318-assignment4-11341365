using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MedicalAppointmentSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnViewDoctors;
        private Button btnBookAppointment;
        private Button btnManageAppointments;
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
            this.btnViewDoctors = new Button();
            this.btnBookAppointment = new Button();
            this.btnManageAppointments = new Button();
            this.lblTitle = new Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(50, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Medical Appointment System";

            // btnViewDoctors
            this.btnViewDoctors.Location = new System.Drawing.Point(150, 100);
            this.btnViewDoctors.Name = "btnViewDoctors";
            this.btnViewDoctors.Size = new System.Drawing.Size(150, 40);
            this.btnViewDoctors.TabIndex = 1;
            this.btnViewDoctors.Text = "View Doctors";
            this.btnViewDoctors.UseVisualStyleBackColor = true;
            this.btnViewDoctors.Click += new System.EventHandler(this.btnViewDoctors_Click);

            // btnBookAppointment
            this.btnBookAppointment.Location = new System.Drawing.Point(150, 160);
            this.btnBookAppointment.Name = "btnBookAppointment";
            this.btnBookAppointment.Size = new System.Drawing.Size(150, 40);
            this.btnBookAppointment.TabIndex = 2;
            this.btnBookAppointment.Text = "Book Appointment";
            this.btnBookAppointment.UseVisualStyleBackColor = true;
            this.btnBookAppointment.Click += new System.EventHandler(this.btnBookAppointment_Click);

            // btnManageAppointments
            this.btnManageAppointments.Location = new System.Drawing.Point(150, 220);
            this.btnManageAppointments.Name = "btnManageAppointments";
            this.btnManageAppointments.Size = new System.Drawing.Size(150, 40);
            this.btnManageAppointments.TabIndex = 3;
            this.btnManageAppointments.Text = "Manage Appointments";
            this.btnManageAppointments.UseVisualStyleBackColor = true;
            this.btnManageAppointments.Click += new System.EventHandler(this.btnManageAppointments_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 320);
            this.Controls.Add(this.btnManageAppointments);
            this.Controls.Add(this.btnBookAppointment);
            this.Controls.Add(this.btnViewDoctors);
            this.Controls.Add(this.lblTitle);
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Medical Appointment System";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}