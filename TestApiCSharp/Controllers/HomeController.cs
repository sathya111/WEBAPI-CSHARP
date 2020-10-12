using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace TestApiCSharp.Controllers
{
    public class HomeController : ApiController
    {

        IList<Employee> employees = new List<Employee>()
         {
            new Employee()
                {
                    EmployeeId = 1, EmployeeName = "Mukesh Kumar", Address = "New Delhi", Department = "IT"
                },
                new Employee()
                {
                    EmployeeId = 2, EmployeeName = "Banky Chamber", Address = "London", Department = "HR"
                },
                new Employee()
                {
                    EmployeeId = 3, EmployeeName = "Rahul Rathor", Address = "Laxmi Nagar", Department = "IT"
                },
                new Employee()
                {
                    EmployeeId = 4, EmployeeName = "YaduVeer Singh", Address = "Goa", Department = "Sales"
                },
                new Employee()
                {
                    EmployeeId = 5, EmployeeName = "Manish Sharma", Address = "New Delhi", Department = "HR"
                },
        };


            [System.Web.Http.HttpGet]
            [System.Web.Http.Route("GetEmployee")]
            public HttpResponseMessage GetAllEmployees()
            {
            var message = Request.CreateResponse(HttpStatusCode.OK, employees);
            return message;
            }

            [System.Web.Http.HttpPost]
            [System.Web.Http.Route("GetEmployeeById")]

            public HttpResponseMessage GetEmployeeDetails(Employee emp)
            {
                var employee = employees.FirstOrDefault(e => e.EmployeeId == emp.EmployeeId);
                if (employee == null)
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                }
            var message = Request.CreateResponse(HttpStatusCode.OK, employee);
            return message;
            }
        }
    }
    public class Employee
    {
        public int EmployeeId
        {
            get;
            set;
        }
        public string EmployeeName
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string Department
    {
        get;
        set;
    }
}