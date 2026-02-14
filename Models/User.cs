using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatStudentsShashin.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Surname {  get; set; }
        public byte[] Photo { get; set; }
        public User(string Lastname, string Firstname, string Surname, byte[] Photo)
        {
            this.Lastname = Lastname;
            this.Firstname = Firstname;
            this.Surname = Surname;
            this.Photo = Photo;
        }
        public string ToFio()
        {
            return $"{Lastname} {Firstname} {Surname}"
        }

    }
}
