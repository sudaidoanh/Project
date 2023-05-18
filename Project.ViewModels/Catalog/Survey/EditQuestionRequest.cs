using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.Survey
{
    public class EditQuestionRequest
    {
        public List<QuestionBase> questionBases { get; set; }
        public int subgroup { get; set; }
    }
}
