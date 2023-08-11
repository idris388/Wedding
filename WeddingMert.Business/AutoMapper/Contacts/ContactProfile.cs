using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.Concrete;
using WeddingMert.Entity.DTOs.Contacts;

namespace WeddingMert.Business.AutoMapper.Contacts
{
    public class ContactProfile:Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactAddDto, Contact>().ReverseMap();
            CreateMap<ContactDto, Contact>().ReverseMap();
        }
    }
}
