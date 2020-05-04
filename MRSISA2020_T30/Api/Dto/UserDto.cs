
using System.Collections.Generic;


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
        public List<string> Role { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public string Telefon { get; set; }
        public string Lbo { get; set; }

        public string AktivacioniToken { get; set; }

    }

    
}


