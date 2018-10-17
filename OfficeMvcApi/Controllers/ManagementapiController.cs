using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OfficeMvcApi.Controllers
{
    public class ManagementapiController : ApiController
    {
        [HttpGet]
        public IEnumerable<Management> GetManagements()
        {
            using (OfficeDbEntities entity = new OfficeDbEntities())
            {
                return entity.Managements.ToList();
            }
        }
        [HttpGet]
        public Management GetManagementById(int id)
        {
            using (OfficeDbEntities entity = new OfficeDbEntities())
            {
                return entity.Managements.FirstOrDefault(e => e.Id == id);
            }
        }
    }
}
