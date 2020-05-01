using System;
using System.Collections.Generic;

namespace Api.mis
{
    public partial class Role
    {
        public Role()
        {
            UserRole = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Uloga { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
