using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebAPITEST.Models;

namespace WebAPITEST.DAL
{
    public class DepartmentDAL
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public DepartmentDAL()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);
            sqlCommand = new SqlCommand();

        }

        public void Save(Department dep)
        {
            sqlConnection.Open();
            sqlCommand = new SqlCommand("ADD_DEPARTMENT", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@DepartmentName", dep.DepartmentName);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public DataTable GetAllDep()
        {
            DataTable departmentTable = new DataTable();

            sqlConnection.Open();
            sqlCommand = new SqlCommand("GET_DEPARTMENT", sqlConnection);
            var ds = new SqlDataAdapter(sqlCommand);
            ds.Fill(departmentTable);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return departmentTable;
        }

        public void UpdateDep(Department dep)
        {

            sqlConnection.Open();
            sqlCommand = new SqlCommand("UPDATE_DEPARTMENT", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@DepartmentID", dep.DepartmentID);
            sqlCommand.Parameters.AddWithValue("@DepartmentName", dep.DepartmentName);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }


        public void DeleteDep(Department dep)
        {

            sqlConnection.Open();
            sqlCommand = new SqlCommand("DELETE_DEPARTMENT", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@DepartmentID", dep.DepartmentID);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }


    }
}