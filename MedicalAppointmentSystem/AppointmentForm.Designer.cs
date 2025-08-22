// AppointmentForm.Designer.cs - COMPLETE FILE
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MedicalAppointmentSystem
{
    partial class AppointmentForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbDoctor;
        private ComboBox cmbPatient;
        private DateTimePicker dtpAppointment;
        private TextBox txtNotes;
        private Button btnBookAppointment;
        private Label lblDoctor;
        private Label lblPatient;
        private Label lblDate;
        private Label lblNotes;

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
            this.cmbDoctor = new ComboBox();
            this.cmbPatient = new ComboBox();
            this.dtpAppointment = new DateTimePicker();
            this.txtNotes = new TextBox();
            this.btnBookAppointment = new Button();
            this.lblDoctor = new Label();
            this.lblPatient = new Label();
            this.lblDate = new Label();
            this.lblNotes = new Label();
            this.SuspendLayout();

            // lblDoctor
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location = new Point(30, 30);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new Size(42, 13);
            this.lblDoctor.TabIndex = 0;
            this.lblDoctor.Text = "Doctor:";

            // cmbDoctor
            this.cmbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDoctor.Location = new Point(120, 27);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new Size(250, 21);
            this.cmbDoctor.TabIndex = 1;

            // lblPatient
            this.lblPatient.AutoSize = true;
            this.lblPatient.Location = new Point(30, 70);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new Size(43, 13);
            this.lblPatient.TabIndex = 2;
            this.lblPatient.Text = "Patient:";

            // cmbPatient
            this.cmbPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPatient.Location = new Point(120, 67);
            this.cmbPatient.Name = "cmbPatient";
            this.cmbPatient.Size = new Size(250, 21);
            this.cmbPatient.TabIndex = 3;

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new Point(30, 110);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new Size(33, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date:";

            // dtpAppointment
            this.dtpAppointment.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpAppointment.Format = DateTimePickerFormat.Custom;
            this.dtpAppointment.Location = new Point(120, 107);
            this.dtpAppointment.Name = "dtpAppointment";
            this.dtpAppointment.ShowUpDown = true;
            this.dtpAppointment.Size = new Size(250, 20);
            this.dtpAppointment.TabIndex = 5;
            this.dtpAppointment.Value = DateTime.Now.AddDays(1);

            // lblNotes
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new Point(30, 150);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new Size(38, 13);
            this.lblNotes.TabIndex = 6;
            this.lblNotes.Text = "Notes:";

            // txtNotes
            this.txtNotes.Location = new Point(120, 147);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = ScrollBars.Vertical;
            this.txtNotes.Size = new Size(250, 80);
            this.txtNotes.TabIndex = 7;

            // btnBookAppointment
            this.btnBookAppointment.Location = new Point(170, 250);
            this.btnBookAppointment.Name = "btnBookAppointment";
            this.btnBookAppointment.Size = new Size(150, 35);
            this.btnBookAppointment.TabIndex = 8;
            this.btnBookAppointment.Text = "Book Appointment";
            this.btnBookAppointment.UseVisualStyleBackColor = true;
            this.btnBookAppointment.Click += new EventHandler(this.btnBookAppointment_Click);

            // AppointmentForm
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(420, 320);
            this.Controls.Add(this.btnBookAppointment);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.dtpAppointment);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbPatient);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.lblDoctor);
            this.Name = "AppointmentForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Book Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}