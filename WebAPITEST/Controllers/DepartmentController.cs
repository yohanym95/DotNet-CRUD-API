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
using System.Web.Script.Serialization;
using System.Web.Mvc;
using WebAPITEST.DAL;

namespace WebAPITEST.Controllers
{
    public class DepartmentController : ApiController
    {
        DepartmentDAL departmentDAL = new DepartmentDAL();

        //api/department - get
        public HttpResponseMessage Get()
        {
            try
            {
                DataTable departmentTable = departmentDAL.GetAllDep();
                var response = responseDetails("OK", "Departments", departmentTable);
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                var response = responseDetails("Bad Request", "ErrorMessage", e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }

        //api/department - post
        public HttpResponseMessage Post(Department dep)
        {

            try
            {
                departmentDAL.Save(dep);
                var response = responseDetails("OK", "Message", "Successfully added the department");
                return Request.CreateResponse(HttpStatusCode.OK,response);
            }
            catch (Exception e)
            {
                var response = responseDetails("Bad Request", "ErrorMessage", e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);

            }
        }

        //api/department - put
        public HttpResponseMessage Put(Department dep)
        {
            try
            {
                departmentDAL.UpdateDep(dep);
                var response = responseDetails("OK", "Message", "Successfully Updated the department");
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                var response = responseDetails("Bad Request", "ErrorMessage", e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }

        //api/department - delete
        public HttpResponseMessage Delete(Department dep)
        {
            try
            {
                departmentDAL.DeleteDep(dep);
                var response = responseDetails("OK", "Message", "Successfully Deleted the department");
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                var response = responseDetails("Bad Request", "ErrorMessage", e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }

        public Dictionary<string, dynamic> responseDetails(string status, String resultMessage, dynamic result)
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
