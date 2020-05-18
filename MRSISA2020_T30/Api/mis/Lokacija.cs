using System;
using System.Collections.Generic;

namespace Api.mis
{
    public partial class Lokacija
    {
        public Lokacija()
        {
            Exam = new HashSet<Exam>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? Aktivan { get; set; }

        public virtual ICollection<Exam> Exam { get; set; }
    }
}
