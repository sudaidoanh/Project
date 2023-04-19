using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class AreaUser
    {
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public int UserId { get; set; }

    }
}
