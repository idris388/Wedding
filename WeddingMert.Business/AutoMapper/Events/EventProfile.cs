using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.Concrete;
using WeddingMert.Entity.DTOs.Events;

namespace WeddingMert.Business.AutoMapper.Events
{
    public class EventProfile:Profile
    {
        public EventProfile()
        {
            CreateMap<EventUpdateDto, Event>().ReverseMap(); 
            CreateMap<EventUpdateDto, EventDto>().ReverseMap();
            CreateMap<EventDto, Event>().ReverseMap();
        }
    }
}
