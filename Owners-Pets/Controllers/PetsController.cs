using System.Web.Http;
using Owners_Pets.Helpers;
using System.Collections.Generic;
using Owners_Pets.Models;

namespace Owners_Pets.Controllers
{
    public class PetsController : ApiController
    {
        public List<Pet> GetPetsById(int id)
        {

            var result = DBHelper.ViewPetsDetails(id);
            return result;
        }

        [HttpPost]
        public IHttpActionResult CreatePet([FromBody]Pet pet)
        {
            if (pet == null)
            {
                return BadRequest("Invalid passed data");
            }
            var name = pet.PetName;
            var ownerId = pet.OwnerId;
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
