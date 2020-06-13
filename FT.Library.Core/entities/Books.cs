using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Library.Core.entities
{
    public class Books
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public int Category_ID { get; set; }
        public int Author_ID { get; set; }
    }
}
