using System;
using System.Windows.Forms;

namespace PharmacyManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Test database connection before starting the application
               
                Application.Run(new MainPharmacyForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start application: {ex.Message}", "Startup Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}