using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owners_Pets.Models
{
    public class Pet
    {
        public long PetId { get; set; }
        public string PetName { get; set; }
        public int OwnerId { get; set; }
    }
}