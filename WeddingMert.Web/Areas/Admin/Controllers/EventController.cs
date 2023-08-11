
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovenaClinic.Business.Services.Abstract;
using NToastNotify;
using WeddingMert.Business.Services.Concrete;
using WeddingMert.Entity.Concrete;
using WeddingMert.Entity.DTOs.Abouts;
using WeddingMert.Entity.DTOs.Events;

namespace NovenaClinic.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly IMapper mapper;
        private readonly IValidator<Event> validator;
        private readonly IToastNotification toast;

        public EventController(IEventService eventService, IMapper mapper, IValidator<Event> validator)
        {
            this.eventService = eventService;
            this.mapper = mapper;
            this.validator = validator;

        }
        [Route("etkinlik/")]
        public async Task<IActionResult> Index()
        {
            var events = await eventService.GetAllEventAsync();
            return View(events);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {

            var events = await eventService.GetEventAsync(id);
            var eventUpdateDto = mapper.Map<EventUpdateDto>(events);
            return View(eventUpdateDto);
        }
        [HttpPost]

        public async Task<IActionResult> Update(EventUpdateDto eventUpdateDto)
        {
            var map = mapper.Map<Event>(eventUpdateDto);
            //var result = await validator.ValidateAsync(map);
            //if (result.IsValid)
            //{
            //    var title = await eventService.UpdateEventAsync(eventUpdateDto);
            //    toast.AddSuccessToastMessage("İşlem başarılı", new ToastrOptions() { Title = "İşlem Başarılı" });
            //    return RedirectToAction("Index", "Event", new { Area = "Admin" });

            //}
            //else
            //{
            //    toast.AddSuccessToastMessage("İşlem başarılı", new ToastrOptions() { Title = "İşlem Başarılı" });

            //    return RedirectToAction("Index", "Event", new { Area = "Admin" });
            //}


            //return View(eventUpdateDto);
            var title = await eventService.UpdateEventAsync(eventUpdateDto);

            return RedirectToAction("Index", "Event", new { Area = "Admin" });
        }
    }
}
