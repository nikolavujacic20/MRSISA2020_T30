using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Aktivan { get; set; }
        public string Token { get; set; }
    }

    
}

//namespace Api.mis
//{ 
//    public partial class User
//    {
//        public string Token { get; set; }
//    }
//}

