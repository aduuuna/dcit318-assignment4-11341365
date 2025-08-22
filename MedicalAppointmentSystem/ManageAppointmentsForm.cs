using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalAppointmentSystem
{
    public partial class ManageAppointmentsForm : Form
    {
        private DataSet appointmentsDataSet;
        private SqlDataAdapter dataAdapter;

        public ManageAppointmentsForm()
        {
            InitializeComponent();
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = @"SELECT a.AppointmentID, d.FullName as DoctorName, 
                                   p.FullName as PatientName, a.AppointmentDate, a.Notes
                                   FROM Appointments a
                                   INNER JOIN Doctors d ON a.DoctorID = d.DoctorID
                                   INNER JOIN Patients p ON a.PatientID = p.PatientID
                                   ORDER BY a.AppointmentDate";

                    dataAdapter = new SqlDataAdapter(query, conn);
                    appointmentsDataSet = new DataSet();
                    dataAdapter.Fill(appointmentsDataSet, "Appointments");

                    dgvAppointments.DataSource = appointmentsDataSet.Tables["Appointments"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAppointment();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAppointment();
        }

        private void UpdateAppointment()
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to update.", "Selection Required",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int appointmentId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["AppointmentID"].Value);

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Appointments SET AppointmentDate = @AppointmentDate, Notes = @Notes " +
                                 "WHERE AppointmentID = @AppointmentID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@AppointmentID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Input,
                            Value = appointmentId
                        });

                        cmd.Parameters.Add(new SqlParameter("@AppointmentDate", SqlDbType.DateTime)
                        {
                            Direction = ParameterDirection.Input,
                            Value = dtpNewDate.Value
                        });

                        cmd.Parameters.Add(new SqlParameter("@Notes", SqlDbType.VarChar)
                        {
                            Direction = ParameterDirection.Input,
                            Value = string.IsNullOrEmpty(txtNewNotes.Text) ? (object)DBNull.Value : txtNewNotes.Text
                        });

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment updated successfully!", "Success",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAppointments();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating appointment: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteAppointment()
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to delete.", "Selection Required",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm Delete",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int appointmentId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["AppointmentID"].Value);

                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        string query = "DELETE FROM Appointments WHERE AppointmentID = @AppointmentID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.Add(new SqlParameter("@AppointmentID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Input,
                                Value = appointmentId
                            });

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Appointment deleted successfully!", "Success",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadAppointments();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting appointment: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvAppointments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAppointments.SelectedRows[0];
                dtpNewDate.Value = Convert.ToDateTime(selectedRow.Cells["AppointmentDate"].Value);
                txtNewNotes.Text = selectedRow.Cells["Notes"].Value?.ToString() ?? "";
            }
        }
    }
}