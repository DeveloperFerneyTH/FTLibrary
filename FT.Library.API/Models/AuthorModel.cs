using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FT.Library.API.Models
{
    public class AuthorModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
