using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovenaClinic.Business.Services.Abstract;
using NToastNotify;
using WeddingMert.Entity.Concrete;
using WeddingMert.Entity.DTOs.Abouts;

namespace NovenaClinic.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutController : Controller
    {
        private readonly IAboutService aboutService;
        private readonly IMapper mapper;
        private readonly IValidator<About> validator;

        private readonly IToastNotification toast;
        public AboutController(IAboutService aboutService, IMapper mapper, IValidator<About> validator, IToastNotification toast)
        {
            this.aboutService = aboutService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        [Route("hakkimizda/")]
        public async Task<IActionResult> Index()
        {
            var about = await aboutService.GetAllAboutAsync();
            return View(about);
        }
        [HttpGet]
        [Route("hakkimizda/{aboutId}")]
        public async Task<IActionResult> Update(Guid aboutId)
        {

            var articles = await aboutService.GetAboutAsync(aboutId);
            var articleUpdateDto = mapper.Map<AboutUpdateDto>(articles);
            return View(articleUpdateDto);
        }
        [HttpPost]
        [Route("hakkimizda/{aboutId}")]
        public async Task<IActionResult> Update(AboutUpdateDto aboutUpdateDto)
        {
            var map = mapper.Map<About>(aboutUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var title = await aboutService.UpdateAboutAsync(aboutUpdateDto);
                toast.AddSuccessToastMessage("İşlem başarılı", new ToastrOptions() { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "About", new { Area = "Admin" });

            }
            else
            {
                toast.AddErrorToastMessage("Başarısız", new ToastrOptions() { Title = "İşlem Başarısız" });
            }

            return View(aboutUpdateDto);
        }
    }
}
