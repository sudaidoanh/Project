using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.Survey
{
    public class QuestionBase
    {
        public string Question { get; set; }
        public List<string> Answer { get; set; }
        public AnswerType AnswerType { get; set; }

    }
}
