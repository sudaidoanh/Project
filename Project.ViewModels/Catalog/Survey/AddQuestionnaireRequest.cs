using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.Survey
{
    public class AddQuestionnaireRequest
    {
        public string Title { get; set; }
        public bool subgroup { get; set; }
    }
}
