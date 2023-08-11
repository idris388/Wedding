using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Core.Concrete;

namespace WeddingMert.Entity.Concrete
{
    public class Contact:EntityBase
    {
        public Contact()
        {
                
        }
        public Contact(string name,string surname,string mail,string phone,string message)
        {
            Name = name;
            Surname = surname;
            Mail = mail;
            Phone = phone;
            Message = message;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}
