using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.mis;

namespace Api.Services
{
    public interface IExamService
    {
        Exam GetExam(int id);
        List<Exam> GetExams(int pacId);
        Exam SaveExam(Exam exam);
        bool CanScheduleExam(Exam exam);
        bool DeleteExam(int id);

    }
}
