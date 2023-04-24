using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.System.Roles
{
    public interface IRolesService
    {
        public class RoleVm
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }
        }
        Task<List<RoleVm>> GetAll();
    }
}
