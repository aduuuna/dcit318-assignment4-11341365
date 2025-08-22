using System;
using System.Configuration;
using System.Data.SqlClient;

namespace MedicalAppointmentSystem
{
    public static class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MedicalDB"].ConnectionString;
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
    }
}