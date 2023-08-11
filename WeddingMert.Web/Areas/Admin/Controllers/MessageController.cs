using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovenaClinic.Business.Services.Abstract;
using WeddingMert.Business.Services.Abstract;
using WeddingMert.Business.Services.Concrete;
using WeddingMert.Entity.Concrete;
using static WeddingMert.Web.ResultMessages.Messages;
using WeddingMert.Entity.DTOs.Abouts;
using WeddingMert.Entity.DTOs.Contacts;

namespace WeddingMert.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class MessageController : Controller
    {
        private readonly IContactService contactService;
        private readonly IMapper mapper;


        public MessageController(IContactService contactService, IMapper mapper)
        {
            this.contactService = contactService;
            this.mapper = mapper;
        }
        [Route("mesajlar/")]
        public async Task<IActionResult> Index()
        {
            var about = await contactService.GetAllContactAsync();
            return View(about);
        }
        [Route("detay/{id}",Name ="detaylar")]
        public async Task<IActionResult> MessageDetails(Guid id)
        {
            var contact = await contactService.GetContactAsync(id);
            var contactDto = mapper.Map<ContactDto>(contact);
            return View(contactDto);
        }
    }
}
