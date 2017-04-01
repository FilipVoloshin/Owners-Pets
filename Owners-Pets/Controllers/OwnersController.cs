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
        public IEnumerable<string> Get()
        {
            DBHelper.StartConnection();
            DBHelper.DeleteOwner(3);
            return new string[] { "value1", "value2" };
        }
    }
}
