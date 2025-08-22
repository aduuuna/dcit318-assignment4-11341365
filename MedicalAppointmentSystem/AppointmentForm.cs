// AppointmentForm.cs - COMPLETE FILE
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalAppointmentSystem
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            LoadDoctors();
            LoadPatients();
        }

        private void LoadDoctors()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT DoctorID, FullName + ' (' + Specialty + ')' as DisplayName " +
                                 "FROM Doctors WHERE Availability = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbDoctor.Items.Add(new ComboBoxItem
                                {
                                    Text = reader["DisplayName"].ToString(),
                                    Value = reader["DoctorID"]
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctors: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPatients()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT PatientID, FullName FROM Patients";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbPatient.Items.Add(new ComboBoxItem
                                {
                                    Text = reader["FullName"].ToString(),
                                    Value = reader["PatientID"]
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patients: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                BookAppointment();
            }
        }

        private bool ValidateInput()
        {
            if (cmbDoctor.SelectedItem == null)
            {
                MessageBox.Show("Please select a doctor.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbPatient.SelectedItem == null)
            {
                MessageBox.Show("Please select a patient.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpAppointment.Value <= DateTime.Now)
            {
                MessageBox.Show("Appointment date must be in the future.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void BookAppointment()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Appointments (DoctorID, PatientID, AppointmentDate, Notes) " +
                                 "VALUES (@DoctorID, @PatientID, @AppointmentDate, @Notes)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@DoctorID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Input,
                            Value = ((ComboBoxItem)cmbDoctor.SelectedItem).Value
                        });

                        cmd.Parameters.Add(new SqlParameter("@PatientID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Input,
                            Value = ((ComboBoxItem)cmbPatient.SelectedItem).Value
                        });

                        cmd.Parameters.Add(new SqlParameter("@AppointmentDate", SqlDbType.DateTime)
                        {
                            Direction = ParameterDirection.Input,
                            Value = dtpAppointment.Value
                        });

                        cmd.Parameters.Add(new SqlParameter("@Notes", SqlDbType.VarChar)
                        {
                            Direction = ParameterDirection.Input,
                            Value = string.IsNullOrEmpty(txtNotes.Text) ? (object)DBNull.Value : txtNotes.Text
                        });

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment booked successfully!", "Success",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error booking appointment: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            cmbDoctor.SelectedIndex = -1;
            cmbPatient.SelectedIndex = -1;
            dtpAppointment.Value = DateTime.Now.AddDays(1);
            txtNotes.Clear();
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}