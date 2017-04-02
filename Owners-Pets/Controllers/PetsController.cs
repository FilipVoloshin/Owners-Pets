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

        public IHttpActionResult CreatePet(string name,int ownerId)
        {
            DBHelper.StartConnection();
            DBHelper.AddPet(name, ownerId);
            return Ok();
        }

        public IHttpActionResult DeletePet(int id)
        {
            DBHelper.StartConnection();
            DBHelper.DeletePet(id);
            return Ok();
        }
    }
}
