using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.Concrete;
using WeddingMert.Entity.DTOs.Abouts;

namespace WeddingMert.Business.AutoMapper.Abouts
{
    public class AboutProfile:Profile
    {
        public AboutProfile()
        {
            CreateMap<AboutDto, About>().ReverseMap();
            CreateMap<AboutUpdateDto, About>().ReverseMap();
            CreateMap<AboutUpdateDto, AboutDto>().ReverseMap();
        }
    }
}
