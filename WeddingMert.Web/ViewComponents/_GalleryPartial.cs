using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NovenaClinic.Business.Services.Abstract;
using WeddingMert.Business.Services.Concrete;

namespace WeddingMert.Web.ViewComponents
{
    public class _GalleryPartial : ViewComponent
    {
        private readonly IGalleryService galleryService;
        private readonly IMapper mapper;

        public _GalleryPartial(IGalleryService galleryService, IMapper mapper)
        {
            this.galleryService = galleryService;
            this.mapper = mapper;
        }

        public async Task< IViewComponentResult >InvokeAsync()
        {

            var gallery = await galleryService.GetAllGalleryAsync();
            return View(gallery);
        }
    }
}
