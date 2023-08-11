using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NovenaClinic.Business.Services.Abstract;
using WeddingMert.Business.Services.Concrete;

namespace WeddingMert.Web.ViewComponents
{
    public class _EventPartial : ViewComponent
    {
        private readonly IEventService eventService;
        private readonly IMapper mapper;

        public _EventPartial(IEventService eventService, IMapper mapper)
        {
            this.eventService = eventService;
            this.mapper = mapper;
        }

        public async Task< IViewComponentResult >InvokeAsync()
        {
            var events = await eventService.GetAllEventAsync();
            return View(events);
        }
    }
}
