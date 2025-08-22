using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyManagementSystem
{
    public partial class SalesReportForm : Form
    {
        public SalesReportForm()
        {
            InitializeComponent();
            LoadSalesReport();
        }

        private void LoadSalesReport()
        {
            try
            {
                using (SqlConnection conn = PharmacyDatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                                        s.SaleID,
                                        m.Name as MedicineName,
                                        m.Category,
                                        s.QuantitySold,
                                        m.Price,
                                        (s.QuantitySold * m.Price) as TotalAmount,
                                        s.SaleDate
                                    FROM Sales s
                                    INNER JOIN Medicines m ON s.MedicineID = m.MedicineID
                                    ORDER BY s.SaleDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dgvSales.DataSource = dt;
                        }
                    }
                }

                CalculateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales report: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotals()
        {
            if (dgvSales.DataSource is DataTable dt)
            {
                decimal totalSales = 0;
                int totalQuantity = 0;

                foreach (DataRow row in dt.Rows)
                {
                    if (decimal.TryParse(row["TotalAmount"].ToString(), out decimal amount))
                        totalSales += amount;

                    if (int.TryParse(row["QuantitySold"].ToString(), out int quantity))
                        totalQuantity += quantity;
                }

                lblTotalSales.Text = $"Total Sales: ₦{totalSales:F2}";
                lblTotalQuantity.Text = $"Total Quantity Sold: {totalQuantity}";
                lblTotalRecords.Text = $"Total Records: {dt.Rows.Count}";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSalesReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFilterByDate_Click(object sender, EventArgs e)
        {
            FilterSalesByDate();
        }

        private void FilterSalesByDate()
        {
            try
            {
                using (SqlConnection conn = PharmacyDatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                                        s.SaleID,
                                        m.Name as MedicineName,
                                        m.Category,
                                        s.QuantitySold,
                                        m.Price,
                                        (s.QuantitySold * m.Price) as TotalAmount,
                                        s.SaleDate
                                    FROM Sales s
                                    INNER JOIN Medicines m ON s.MedicineID = m.MedicineID
                                    WHERE s.SaleDate >= @StartDate AND s.SaleDate <= @EndDate
                                    ORDER BY s.SaleDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime)
                        {
                            Direction = ParameterDirection.Input,
                            Value = dtpStartDate.Value.Date
                        });

                        cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime)
                        {
                            Direction = ParameterDirection.Input,
                            Value = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1)
                        });

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dgvSales.DataSource = dt;
                        }
                    }
                }

                CalculateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering sales: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}