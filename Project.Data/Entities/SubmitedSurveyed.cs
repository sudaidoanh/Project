using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class SubmitedSurveyed
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int SurveyedId { get; set; }
        public int QuestionnaireDetailId { get; set; }
        public string Answer { get; set; }
        public List<SubmitedSurveyedAnswer> SubmitedSurveyedAnswer { get; set; }

    }
}
