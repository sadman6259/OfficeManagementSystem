using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OfficeMvcApi.Controllers
{
    public class BillsapiController : ApiController
    {
        [HttpGet]
        public IEnumerable<Bill> GetBills()
        {
            using (OfficeDbEntities entity = new OfficeDbEntities())
            {
                return entity.Bills.ToList();
            }
        }
        [HttpGet]
        public Bill GetClarkById(int id)
        {
            using (OfficeDbEntities entity = new OfficeDbEntities())
            {
                return entity.Bills.FirstOrDefault(e => e.Id == id);
            }
        }
    }
}
