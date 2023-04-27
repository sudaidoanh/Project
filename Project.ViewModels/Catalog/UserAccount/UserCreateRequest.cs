﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.UserAccount
{
    public class UserCreateRequest
    {
        public string Address { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public Guid RoleId { get; set; }
        public int AreaId { get; set; }

    }
}
