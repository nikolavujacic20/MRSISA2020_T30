using System;
using System.Collections.Generic;

namespace Api.mis
{
    public partial class Pacijent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BloodType { get; set; }
        public string Jmbg { get; set; }
        public string Lbo { get; set; }
        public DateTime Birth { get; set; }
        public int Active { get; set; }
    }
}
