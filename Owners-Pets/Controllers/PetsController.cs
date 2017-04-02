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

        public void CreatePet(string name,int ownerId)
        {
            DBHelper.AddPet(name, ownerId);
        }

        public void DeletePet(int id)
        {
            DBHelper.DeletePet(id);
        }
    }
}
