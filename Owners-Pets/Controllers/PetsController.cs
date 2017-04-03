using System.Web.Http;
using Owners_Pets.Helpers;
using System.Collections.Generic;

namespace Owners_Pets.Controllers
{
    public class PetsController : ApiController
    {
        public List<string> GetPetsById(int id)
        {
            
            var result = DBHelper.ViewOwnerDetails(id);
            return result;
        }

        [HttpPost]
        public IHttpActionResult CreatePet(string name,int ownerId)
        {
            if (name == null || ownerId == 0)
            {
                return BadRequest("Invalid passed data");
            }
            DBHelper.AddPet(name, ownerId);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeletePet(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid passed data");
            }
            DBHelper.DeletePet(id);
            return Ok();
        }
    }
}
