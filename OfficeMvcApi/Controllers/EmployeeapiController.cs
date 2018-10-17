using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OfficeMvcApi.Controllers
{
    public class EmployeeapiController : ApiController
    {
        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            using (OfficeDbEntities entity = new OfficeDbEntities())
            {
                return entity.Employees.ToList();
            }
        }
        [HttpGet]
        public Employee GetEmployeeById(int id)
        {
            using (OfficeDbEntities entity = new OfficeDbEntities())
            {
                return entity.Employees.FirstOrDefault(e => e.Id == id);
            }
        }
    }
}
