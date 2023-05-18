using Project.ViewModels.Catalog.Survey;
using Project.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Catalog.Survey
{
    public interface ISurveyService
    {
        Task<bool> CreateQuestionnaire(Guid userCreated, AddQuestionnaireRequest request);
        Task<ResultModel<QuestionnaireViewModel>> GetQuestionnaire(Guid userCreate, GetQuestionnairePagingRequest request);
        Task<int> EditQuestionnaire(int questionnaireId, EditQuestionRequest request);
        Task<bool> EditQuestion(int questionnaireDetailId, QuestionBase question);
        Task<ResultModel<SurveyViewModel>> getSurvey(Guid userCreated);
        Task<int> CreateSurvey(Guid userCreated, CreateSurveyRequest request);
        Task<int> CreateNewSurvey(Guid userCreatted, CreateSurveyRequest request);
    }
}
