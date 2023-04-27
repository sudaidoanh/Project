using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class UserImage
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string ImagePath { get; set; }
        public bool CurrentSet { get; set; }
        public DateTime DateCreated { get; set; }
        public int SortOder { get; set; }
        public long FileSize { get; set; }
        public AppUser User { get; set; }
    }
}
