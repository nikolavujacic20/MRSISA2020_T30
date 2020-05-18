using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.mis;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class ExamService : IExamService
    {
        private readonly misContext _context;
        public ExamService(misContext context)
        {
            _context = context;
        }

        public Exam GetExam(int id)
        {
            return _context.Exam.FirstOrDefault(x => x.Id == id);
        }

        public List<Exam> GetExams(int pacId)
        {
            return _context.Exam
                .Where(x => x.PacijentId == pacId /*&& x.Active == 1*/)
                .Select(x => new Exam
                {
                    Id = x.Id,
                    Datetime = x.Datetime,
                    ExamType = x.ExamType,
                    Anameza = x.Anameza,
                    Zakljucak = x.Zakljucak,
                    LocationId = x.LocationId,
                    PacijentId = x.PacijentId,
                    DoctorId = x.DoctorId,
                    Price = x.Price,
                    DiscountPrice = x.DiscountPrice,
                    Taken = x.Taken,
                    Location = x.Location,
                    Pacijent = x.Pacijent,
                    Doctor = x.Doctor
                }).OrderByDescending(x => x.Datetime)
                .ToList();
        }

        public Exam SaveExam(Exam exam)
        {
            var dbExam = _context.Exam.Where(x => x.Id == exam.Id).FirstOrDefault();

            if(dbExam == null)
            { 
                _context.Exam.Add(exam);
                _context.SaveChanges();

                return exam;
            } else
            {
                dbExam.Datetime = exam.Datetime;
                dbExam.ExamType = exam.ExamType;
                dbExam.Anameza = exam.Anameza;
                dbExam.Zakljucak = exam.Zakljucak;
                dbExam.LocationId = exam.LocationId;
                dbExam.PacijentId = exam.PacijentId;
                dbExam.DoctorId = exam.DoctorId;
                dbExam.Price = exam.Price;
                dbExam.DiscountPrice = exam.DiscountPrice;
                dbExam.Taken = exam.Taken;
                //dbExam.Active = exam.Active;

                _context.SaveChanges();

                return dbExam;
            }
        }

        public bool CanScheduleExam(Exam exam)
        {
            var dbExam = _context.Exam.Where(x =>
            x.DoctorId == exam.DoctorId &&
            x.Datetime == exam.Datetime).FirstOrDefault();

            if(dbExam != null)
            {
                return false;
            }
            {
                return true;
            }

        }

        public bool DeleteExam(int id)
        {
            var exam = this.GetExam(id);
            if(exam != null)
            {
                _context.Exam.Remove(exam);
                _context.SaveChanges();

            }
            return true;
        }
    }
}
