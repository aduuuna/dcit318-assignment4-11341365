using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyManagementSystem
{
    public partial class MainPharmacyForm : Form
    {
        public MainPharmacyForm()
        {
            InitializeComponent();
            LoadAllMedicines();
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                AddMedicine();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchMedicines();
        }

        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            UpdateStock();
        }

        private void btnRecordSale_Click(object sender, EventArgs e)
        {
            RecordSale();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadAllMedicines();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtMedicineName.Text))
            {
                MessageBox.Show("Please enter medicine name.", "Validation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMedicineName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Please enter category.", "Validation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategory.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Validation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return false;
            }

            return true;
        }

        private void AddMedicine()
        {
            try
            {
                using (SqlConnection conn = PharmacyDatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("AddMedicine", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 255)
                        {
                            Direction = ParameterDirection.Input,
                            Value = txtMedicineName.Text.Trim()
                        });

                        cmd.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar, 100)
                        {
                            Direction = ParameterDirection.Input,
                            Value = txtCategory.Text.Trim()
                        });

                        cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Input,
                            Value = Convert.ToDecimal(txtPrice.Text)
                        });

                        cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Input,
                            Value = Convert.ToInt32(txtQuantity.Text)
                        });

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Medicine added successfully!", "Success",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                            LoadAllMedicines();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding medicine: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchMedicines()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadAllMedicines();
                return;
            }

            try
            {
                using (SqlConnection conn = PharmacyDatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SearchMedicine", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@SearchTerm", SqlDbType.VarChar, 255)
                        {
                            Direction = ParameterDirection.Input,
                            Value = txtSearch.Text.Trim()
                        });

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dgvMedicines.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching medicines: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStock()
        {
            if (dgvMedicines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a medicine to update stock.", "Selection Required",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter new stock quantity:", "Update Stock", "0");

            if (string.IsNullOrEmpty(input))
                return;

            if (!int.TryParse(input, out int newQuantity) || newQuantity < 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Invalid Input",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int medicineId = Convert.ToInt32(dgvMedicines.SelectedRows[0].Cells["MedicineID"].Value);

                using (SqlConnection conn = PharmacyDatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateStock", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@MedicineID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Input,
                            Value = medicineId
                        });

                        cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Input,
                            Value = newQuantity
                        });

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Stock updated successfully!", "Success",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAllMedicines();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating stock: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecordSale()
        {
            if (dgvMedicines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a medicine to record sale.", "Selection Required",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter quantity sold:", "Record Sale", "1");

            if (string.IsNullOrEmpty(input))
                return;

            if (!int.TryParse(input, out int quantitySold) || quantitySold <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Invalid Input",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int medicineId = Convert.ToInt32(dgvMedicines.SelectedRows[0].Cells["MedicineID"].Value);

                using (SqlConnection conn = PharmacyDatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("RecordSale", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@MedicineID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Input,
                            Value = medicineId
                        });

                        cmd.Parameters.Add(new SqlParameter("@QuantitySold", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Input,
                            Value = quantitySold
                        });

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Sale recorded successfully!", "Success",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAllMedicines();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Insufficient stock"))
                {
                    MessageBox.Show("Insufficient stock available for this sale.", "Stock Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error recording sale: {ex.Message}", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error recording sale: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllMedicines()
        {
            try
            {
                using (SqlConnection conn = PharmacyDatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetAllMedicines", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dgvMedicines.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading medicines: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtMedicineName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtMedicineName.Focus();
        }

        private void dgvMedicines_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMedicines.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMedicines.SelectedRows[0];
                // You can populate form fields with selected medicine data if needed
                lblSelectedMedicine.Text = $"Selected: {selectedRow.Cells["Name"].Value}";
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Auto-search as user types
            if (txtSearch.Text.Length >= 2 || string.IsNullOrEmpty(txtSearch.Text))
            {
                SearchMedicines();
            }
        }

        private void btnViewSalesReport_Click(object sender, EventArgs e)
        {
            SalesReportForm salesReportForm = new SalesReportForm();
            salesReportForm.ShowDialog();
        }
    }
}