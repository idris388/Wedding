using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.ComponentModel.DataAnnotations;
using WeddingMert.Business.Services.Abstract;
using WeddingMert.Entity.Concrete;
using WeddingMert.Entity.DTOs.Contacts;
using WeddingMert.Web.ResultMessages;

namespace WeddingMert.Web.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IContactService contactService;
        private readonly IMapper mapper;
        private readonly IValidator<Contact> validator;
        private readonly IToastNotification toast;
        public DefaultController(IContactService contactService, IMapper mapper, IValidator<Contact> validator, IToastNotification toast)
        {
            this.contactService = contactService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult _ContactPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> _ContactPartial(ContactAddDto contactAddDto)
        {
            var map = mapper.Map<Contact>(contactAddDto);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await contactService.SendMessageAsync(contactAddDto);
                toast.AddSuccessToastMessage(Messages.Contact.Add(contactAddDto.Name), new ToastrOptions { Title = "Mesaj Gönderme Başarılı" });
                return RedirectToAction("Index", "Default");
            }
            else
            {
                result.AddToModelState(this.ModelState);
                toast.AddErrorToastMessage("Lütfen Tekrar Deneyiniz", new ToastrOptions { Title = "Mesaj Gönderme Başarısız" });
                return RedirectToAction("Index", "Default");
            }
        }
    }
}
