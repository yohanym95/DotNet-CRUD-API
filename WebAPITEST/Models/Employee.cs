﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITEST.Models
{
    public class Employee
    {
        public long EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string MailId { get; set; }
        public DateTime? DOJ { get; set; }

    }
}