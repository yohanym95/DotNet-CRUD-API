using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


using WebAPITEST.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebAPITEST.DAL;

namespace WebAPITEST.Controllers
{
    public class EmployeeController : ApiController
    {

        EmployeeDAL employeeDAL = new EmployeeDAL();

        //api/employee - get
        public HttpResponseMessage Get()
        {
            try
            {
                DataTable employeeTable = employeeDAL.GetAllEmp();
                var response = responseDetails("OK", "Employees", employeeTable);
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                var response = responseDetails("Bad Request", "ErrorMessage", e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }

        }

        //api/employee - post
        public HttpResponseMessage Post(Employee emp)
        {
            try
            {
                employeeDAL.SaveEmp(emp);
                var response = responseDetails("OK", "Message", "Successfully added the Employeee");
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                var response = responseDetails("Bad Request", "ErrorMessage", e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);

            }
        }

        //api/employee -  put
        public HttpResponseMessage Put(Employee emp)
        {
            try
            {
                employeeDAL.UpdateEmp(emp);
                var response = responseDetails("OK", "Message", "Successfully Updated the Employee");
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                var response = responseDetails("Bad Request", "ErrorMessage", e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }

        //api/employee - delete
        public HttpResponseMessage Delete(Employee emp)
        {
            try
            {
                employeeDAL.DeleteEmp(emp);
                var response = responseDetails("OK", "Message", "Successfully Deleted the Employee");
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                var response = responseDetails("Bad Request", "ErrorMessage", e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }

        }

        public Dictionary<string, dynamic> responseDetails(string status, string resultMessage, dynamic result)
        {
            var map = new Dictionary<string, dynamic>();
            if (status.Equals("OK"))
            {
                map.Add("Status", status);
                map.Add("Error", false);
                map.Add(resultMessage, result);
            }
            else
            {
                map.Add("Status", status);
                map.Add("Error", true);
                map.Add(resultMessage, result);
            }

            return map;

        }
    }
}
