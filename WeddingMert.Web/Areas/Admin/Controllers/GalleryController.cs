using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovenaClinic.Business.Services.Abstract;
using NToastNotify;
using System.Data;
using WeddingMert.Entity.Concrete;
using WeddingMert.Entity.DTOs.Galleries;
using WeddingMert.Web.ResultMessages;

namespace WeddingMert.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class GalleryController : Controller
    {
        private readonly IGalleryService galleryService;
        private readonly IMapper mapper;
        private readonly IValidator<Gallery> validator;
        private readonly IToastNotification toast;
        public GalleryController(IGalleryService galleryService, IMapper mapper, IValidator<Gallery> validator, IToastNotification toast)
        {
            this.galleryService = galleryService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        [Route("galeri/")]
        public  async Task <IActionResult>Index()
        {
            var galleries = await galleryService.GetAllGalleryAsync();
            return View(galleries);
        }

        [HttpGet]
        [Route("fotografekle/")]
        public async Task<IActionResult> Add()
        {
            return View();           
        }
        [HttpPost]
        [Route("fotografekle/")]
        public async Task<IActionResult> Add(GalleryAddDto galleryAddDto)
        {
            var map = mapper.Map<Gallery>(galleryAddDto);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await galleryService.CreateGalleryAsync(galleryAddDto);
                toast.AddSuccessToastMessage(Messages.Gallery.Add(galleryAddDto.Title), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Gallery", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                toast.AddErrorToastMessage("Başarısız", new ToastrOptions() { Title = "İşlem Başarısız" });
            }
            result.AddToModelState(this.ModelState);
            return View();

        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var title = await galleryService.SafeDeleteGalleryAsync(id);
            toast.AddSuccessToastMessage("Fotoğraf", new ToastrOptions { Title = "Silme işlemi başarılı" });
            return RedirectToAction("Index", "Gallery", new { Area = "Admin" });
        }
    }
}
