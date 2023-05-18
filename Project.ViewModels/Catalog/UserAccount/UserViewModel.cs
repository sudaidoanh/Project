using Microsoft.AspNetCore.Http;
using Project.Data.Entities;
using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.UserAccount
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Area { get; set; }
        public Status Status { get; set; }
        public string imagePath{ get; set; }
    }
}
