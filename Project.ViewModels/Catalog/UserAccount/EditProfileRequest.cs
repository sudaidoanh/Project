using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.UserAccount
{
    public class EditProfileRequest
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public IFormFile ThumnailImage { get; set; }
    }
}
