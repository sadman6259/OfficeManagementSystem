using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OfficeMvcApi.Controllers
{
    public class AdditionalapiController : ApiController
    {
        [HttpGet]
        public IEnumerable<Additional> GetAddiotionals()
        {
            using (OfficeDbEntities entity = new OfficeDbEntities())
            {
                return entity.Additionals.ToList();
            }
        }
        [HttpGet]
        public Additional GetAdditionalById(int id)
        {
            using (OfficeDbEntities entity = new OfficeDbEntities())
            {
                return entity.Additionals.FirstOrDefault(e => e.Id == id);
            }
        }
    }
}
