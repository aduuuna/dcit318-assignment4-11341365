using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace MedicalAppointmentSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        
        private void btnViewDoctors_Click(object sender, EventArgs e)
        {
            DoctorListForm doctorForm = new DoctorListForm();
            doctorForm.ShowDialog();
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            AppointmentForm appointmentForm = new AppointmentForm();
            appointmentForm.ShowDialog();
        }

        private void btnManageAppointments_Click(object sender, EventArgs e)
        {
            ManageAppointmentsForm manageForm = new ManageAppointmentsForm();
            manageForm.ShowDialog();
        }
    }
}