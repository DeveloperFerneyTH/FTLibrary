using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FT.Library.API.Models
{
    public class BookModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public int Author_ID { get; set; }
        public string Author_Name { get; set; }
    }
}
