using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Owners_Pets.Models;
using Owners_Pets.Helpers;

namespace Owners_Pets.Controllers
{
    
    public class OwnershipsController : ApiController
    {
        [HttpGet]
        public List<Information> GetOwners()
        {
            var listOfInformation = DBHelper.ViewFullDetails();
            return listOfInformation;
        }

        [HttpPost]
        public void CreateOwner(string name)
        {
            DBHelper.AddOwner(name);
        }

        [HttpDelete]
        public void DeleteOwner(int id)
        {
            DBHelper.DeleteOwner(id);
        }
    }
}
