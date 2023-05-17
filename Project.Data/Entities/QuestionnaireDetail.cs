using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class QuestionnaireDetail
    {
        public int Id { get; set; }
        public int QuestionnaireId { get; set; }
        public string Question { get; set; }
        public string Answers { get; set; }
        public string TypeAnswer { get; set; }
        public List<SubmitedSurveyedAnswer> SubmitedSurveyedAnswers { get; set; }
    }
}
