using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class Manage
    {
        public int Id { get; set; }
        public int? ManagerRoleId { get; set; }
        public int? ManagedRoleId { get; set; }

    }
}
