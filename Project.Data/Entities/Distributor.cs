using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class Distributor
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }

    }
}
