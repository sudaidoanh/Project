using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.Survey
{
    public class QuestionnaireViewModal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public List<string> Answers { get; set; }

    }
}
