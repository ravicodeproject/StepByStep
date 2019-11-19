using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }    
        [StringLength(8,MinimumLength=4,ErrorMessage="You must specify password between 4 and 8 characters.")]
        public string password { get; set; }  
        public string Efirstname { get; set; }
        public string Elastname { get; set; }
        public int Eage { get; set; }
        public string Egender { get; set; }
        public DateTime Edateofbirth { get; set; }
        public string Eemail { get; set; }
        public string Elanguages { get; set; }
        public string Eskills { get; set; }
        public string Ereligion { get; set; }
        public string Enationality { get; set; }
        public string Ecaste { get; set; }
    }
}