using Microsoft.AspNetCore.Identity;
using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Address { get; set; }
        public string FullName { get; set; }
        public Status Status { get; set; }
        public List<AreaUser> AreaUser { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<SystemActivity> SystemActivities{ get; set; }
        public List<Report> Reports { get; set; }
        public List<UserImage> UserImages { get; set; }
    }
}
