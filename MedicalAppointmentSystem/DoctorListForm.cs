using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalAppointmentSystem
{
    public partial class DoctorListForm : Form
    {
        public DoctorListForm()
        {
            InitializeComponent();
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT DoctorID, FullName, Specialty, " +
                                 "CASE WHEN Availability = 1 THEN 'Available' ELSE 'Unavailable' END as Status " +
                                 "FROM Doctors";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dgvDoctors.DataSource = dt;
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterDoctors();
        }

        private void cmbSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDoctors();
        }

        private void FilterDoctors()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT DoctorID, FullName, Specialty, " +
                                 "CASE WHEN Availability = 1 THEN 'Available' ELSE 'Unavailable' END as Status " +
                                 "FROM Doctors WHERE 1=1";

                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    {
                        query += " AND FullName LIKE @search";
                    }

                    if (cmbSpecialty.SelectedItem != null && cmbSpecialty.SelectedItem.ToString() != "All")
                    {
                        query += " AND Specialty = @specialty";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(txtSearch.Text))
                        {
                            cmd.Parameters.Add(new SqlParameter("@search", SqlDbType.VarChar)
                            { Value = $"%{txtSearch.Text}%" });
                        }

                        if (cmbSpecialty.SelectedItem != null && cmbSpecialty.SelectedItem.ToString() != "All")
                        {
                            cmd.Parameters.Add(new SqlParameter("@specialty", SqlDbType.VarChar)
                            { Value = cmbSpecialty.SelectedItem.ToString() });
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dgvDoctors.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering doctors: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoctorListForm_Load(object sender, EventArgs e)
        {
            LoadSpecialties();
        }

        private void LoadSpecialties()
        {
            try
            {
                cmbSpecialty.Items.Add("All");
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT DISTINCT Specialty FROM Doctors";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbSpecialty.Items.Add(reader["Specialty"].ToString());
                            }
                        }
                    }
                }
                cmbSpecialty.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading specialties: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}