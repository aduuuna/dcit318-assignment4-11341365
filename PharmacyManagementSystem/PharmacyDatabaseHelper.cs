using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace PharmacyManagementSystem
{
    public static class PharmacyDatabaseHelper
    {
        public static string GetConnectionString()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["PharmacyDB"]?.ConnectionString;

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string 'PharmacyDB' not found in App.config");
                }

                return connectionString;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error retrieving connection string: {ex.Message}");
            }
        }

        public static SqlConnection GetConnection()
        {
            try
            {
                return new SqlConnection(GetConnectionString());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error creating connection: {ex.Message}");
            }
        }

        // Test connection method
        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection test failed: {ex.Message}");
                return false;
            }
        }

        // Get connection with automatic error handling
        public static SqlConnection GetConnectionSafe()
        {
            try
            {
                var connection = GetConnection();
                connection.Open();
                return connection;
            }
            catch (SqlException sqlEx)
            {
                throw new InvalidOperationException($"SQL Server connection failed: {sqlEx.Message}. Make sure SQL Server is running and the database exists.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Connection failed: {ex.Message}");
            }
        }
    }
}