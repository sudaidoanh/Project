﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class Area
    {
        public int Id { get; set; }
        public String? Name { get; set;}
        public string Code { get; set;}

        public List<AreaDistributor> AreaDistributors { get; set; }
        public List<AreaUser> AreaUsers { get; set; }

    }
}
