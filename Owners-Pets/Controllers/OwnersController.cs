using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Owners_Pets.Models;
using Owners_Pets.Helpers;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Net.Http;
using System.Net;

namespace Owners_Pets.Controllers
{
    public class OwnershipsController : ApiController
    {
        public IEnumerable<Information> Get()
        {
            var listOfInformation = DBHelper.ViewFullDetails();
            return listOfInformation;
        }

        [HttpPost]
        public IHttpActionResult CreateOwner([FromBody]Owner owner)
        {
            var name = owner.Name;
            DBHelper.AddOwner(name);
            return Ok(true);
        }

        [HttpDelete]
        public IHttpActionResult DeleteOwner(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid passed data");
            }
            DBHelper.DeleteOwner(id);

            return Ok();
        }
    }
}
