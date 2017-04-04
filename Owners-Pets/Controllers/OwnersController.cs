using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Owners_Pets.Models;
using Owners_Pets.Helpers;
using System.Web.Http.Cors;
using System.Web.Http.OData;

namespace Owners_Pets.Controllers
{
    [EnableCors("http://localhost:60958", "*", "*")]
    public class OwnershipsController : ApiController
    {
        [EnableQuery()]
        public IQueryable<Information> Get()
        {
            var listOfInformation = DBHelper.ViewFullDetails();
            return listOfInformation.AsQueryable();
        }

        [HttpPost]
        public void CreateOwner([FromBody] string name)
        {
            DBHelper.AddOwner(name);
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
