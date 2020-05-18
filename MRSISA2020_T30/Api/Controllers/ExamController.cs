using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.mis;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {

        protected IExamService _examService;
        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public Exam GetById(int id)
        {
            var exam = _examService.GetExam(id);
            if(exam != null)
            {
                if (Convert.ToInt32(HttpContext.User.Identity.Name) == exam.PacijentId)
                {
                    return exam;
                }
            }
            return null;
        }

        [Authorize]
        [HttpGet("list/{id}")]
        public List<Exam> GetExamList(int id)
        {
            var exam = new List<Exam>();
            if (Convert.ToInt32(HttpContext.User.Identity.Name) == id)
            {
                var lista = _examService.GetExams(id);
                if(lista != null)
                {
                    exam = lista;
                }
            }
            return exam;
        }

        [Authorize]
        [HttpPost("zakazi")]
        public Exam ZakaziPregled(Exam exam)
        {
            if(Convert.ToInt32(HttpContext.User.Identity.Name) == exam.PacijentId)
            {
                if (_examService.CanScheduleExam(exam))
                {
                   return _examService.SaveExam(exam);
                }
            }
            return null;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public bool OtkaziPregled(int id)
        {
            var exam = _examService.GetExam(id);
            if(exam != null && Convert.ToInt32(HttpContext.User.Identity.Name) == exam.PacijentId)
            {
                return _examService.DeleteExam(id);
            }
            return false;    
        }
    }
}