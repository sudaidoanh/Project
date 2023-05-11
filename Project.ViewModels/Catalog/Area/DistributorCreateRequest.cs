using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.Area
{
    public class DistributorCreateRequest
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Address { get; set;}
        public string Email { get; set;}
        public string Phone { get; set;}
        public int AreaId { get; set;}
    }
}
