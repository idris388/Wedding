using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NovenaClinic.Business.Services.Abstract;

namespace WeddingMert.Web.ViewComponents
{
    public class _AboutPartial : ViewComponent
    {
        private readonly IAboutService aboutService;
        private readonly IMapper mapper;
        public _AboutPartial(IMapper mapper, IAboutService aboutService)
        {
            this.mapper = mapper;
            this.aboutService = aboutService;
        }
        public async  Task<IViewComponentResult>InvokeAsync()
        {
            var about = await aboutService.GetAllAboutAsync();
            return View(about);
        }
    }
}
