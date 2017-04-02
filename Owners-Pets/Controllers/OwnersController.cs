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

        public List<Information> Get()
        {
            var listOfInformation = DBHelper.ViewFullDetails();
            return listOfInformation;
        }

        //public string GetCount()
        //{
        //    var count = DBHelper.GetOwnersCount();
        //    return count;
        //}

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
