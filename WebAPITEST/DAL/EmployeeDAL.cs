using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebAPITEST.Models;

namespace WebAPITEST.DAL
{
    public class EmployeeDAL
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public EmployeeDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);
            sqlCommand = new SqlCommand();

        }

        public void SaveEmp(Employee emp)
        {
            sqlConnection.Open();
            sqlCommand = new SqlCommand("ADD_EMPLOYEE", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
            sqlCommand.Parameters.AddWithValue("@Department", emp.Department);
            sqlCommand.Parameters.AddWithValue("@MailId", emp.MailId);
            sqlCommand.Parameters.AddWithValue("@DOJ", emp.DOJ);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public DataTable GetAllEmp()
        {
            DataTable employeeTable = new DataTable();

            sqlConnection.Open();
            sqlCommand = new SqlCommand("GET_EMPLOYEE", sqlConnection);
            var ds = new SqlDataAdapter(sqlCommand);
            ds.Fill(employeeTable);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return employeeTable;
        }

        public void UpdateEmp(Employee emp)
        {

            sqlConnection.Open();
            sqlCommand = new SqlCommand("UPDATE_EMPLOYEE", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID );
            sqlCommand.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
            sqlCommand.Parameters.AddWithValue("@Department", emp.Department);
            sqlCommand.Parameters.AddWithValue("@MailId", emp.MailId);
            sqlCommand.Parameters.AddWithValue("@DOJ", emp.DOJ);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DeleteEmp(Employee emp)
        {

            sqlConnection.Open();
            sqlCommand = new SqlCommand("DELETE_EMPLOYEE", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

    }
}