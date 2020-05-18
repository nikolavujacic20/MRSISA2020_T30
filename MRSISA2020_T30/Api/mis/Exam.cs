using System;
using System.Collections.Generic;

namespace Api.mis
{
    public partial class Exam
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public string ExamType { get; set; }
        public string Anameza { get; set; }
        public string Zakljucak { get; set; }
        public int? LocationId { get; set; }
        public int? PacijentId { get; set; }
        public int? DoctorId { get; set; }
        public int? Price { get; set; }
        public int? DiscountPrice { get; set; }
        public int? Taken { get; set; }

        public virtual User Doctor { get; set; }
        public virtual Lokacija Location { get; set; }
        public virtual User Pacijent { get; set; }
    }
}
