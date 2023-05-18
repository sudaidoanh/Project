using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Catalog.Survey;
using Project.ViewModels.Catalog.Survey;

namespace Project.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        public SurveysController(ISurveyService surveyService) { _surveyService = surveyService; }


        [HttpPost("Questionnaire")]
        public async Task<IActionResult> AddQuestionnaire(Guid userCreate, [FromForm] AddQuestionnaireRequest request)
        {
            var questionnaire = await _surveyService.CreateQuestionnaire(userCreate, request);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(questionnaire);
        }

        [HttpGet("Questionnaire")]
        public async Task<IActionResult> GetQuestionnaire( Guid userCreate, [FromQuery] GetQuestionnairePagingRequest request)
        {
            var questionnaire = await _surveyService.GetQuestionnaire(userCreate, request);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(questionnaire);
        }

        [HttpPost("Questionnaire/{id}")]
        public async Task<IActionResult> EditQuestionnaire(int id, [FromBody] EditQuestionRequest request)
        {
            var questionnaire = await _surveyService.EditQuestionnaire(id, request);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(questionnaire);
        }

        [HttpPatch("Questionnaire/{id}")]
        public async Task<IActionResult> EditQuestion(int id, [FromBody] QuestionBase request)
        {
            var questionnaire = await _surveyService.EditQuestion(id, request);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(questionnaire);
        }

        [HttpGet("Surveys")]
        public async Task<IActionResult> GetSurvey(Guid userCreated)
        {
            var data = await _surveyService.getSurvey(userCreated);
            if(data == null)
            {
                return BadRequest();
            } 
            return Ok(data);
        }

        [HttpPost("Surveys")]
        public async Task<IActionResult> CreateSurvey(Guid userCreated, [FromBody] CreateSurveyRequest request)
        {
            var data = await _surveyService.CreateSurvey(userCreated, request);
            if (data == 0)
            {
                return BadRequest();
            }
            return Ok(data);
        }
    }
}
