using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.Concrete;
using WeddingMert.Entity.DTOs.Galleries;

namespace WeddingMert.Business.AutoMapper.Gallery
{
    public class GalleryProfile:Profile
    {
        public GalleryProfile()
        {
            CreateMap<GalleryAddDto, WeddingMert.Entity.Concrete.Gallery>().ReverseMap();
            CreateMap<GalleryDto, WeddingMert.Entity.Concrete.Gallery>().ReverseMap();
         
        }
    }
}
