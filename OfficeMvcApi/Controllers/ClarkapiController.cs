using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OfficeMvcApi.Controllers
{
    public class ClarkapiController : ApiController
    {
        [HttpGet]
        public IEnumerable<Clark> GetClarks()
        {
            using (OfficeDbEntities entity = new OfficeDbEntities())
            {
                return entity.Clarks.ToList();
            }
        }
        [HttpGet]
        public Clark GetClarkById(int id)
        {
            using (OfficeDbEntities entity = new OfficeDbEntities())
            {
                return entity.Clarks.FirstOrDefault(e => e.Id == id);
            }
        }
    }
}
