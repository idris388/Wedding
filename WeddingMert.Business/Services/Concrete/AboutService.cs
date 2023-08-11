using AutoMapper;
using Microsoft.AspNetCore.Http;
using NovenaClinic.Business.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Business.Helpers.Images;
using WeddingMert.DataAccess.UnitOfWorks;
using WeddingMert.Entity.Concrete;
using WeddingMert.Entity.DTOs.Abouts;
using WeddingMert.Entity.Enums;

namespace WeddingMert.Business.Services.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper ımageHelper;
        private readonly ClaimsPrincipal _user;
        public AboutService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper ımageHelper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.ımageHelper = ımageHelper;
            _user = httpContextAccessor.HttpContext.User;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<AboutDto> GetAboutAsync(Guid aboutId)
        {

            var article = await _unitOfWork.GetRepository<About>().GetAsync(x => !x.IsDeleted && x.Id == aboutId, y => y.Image);
            var map = mapper.Map<AboutDto>(article);
            return map;
        }

        public async Task<List<AboutDto>> GetAllAboutAsync()
        {
            var about = await _unitOfWork.GetRepository<About>().GetAllAsync(x => !x.IsDeleted, y => y.Image);
            var map = mapper.Map<List<AboutDto>>(about);
            return map;
        }

        public async Task<string> UpdateAboutAsync(AboutUpdateDto aboutUpdateDto)
        {
            var userEmail = "deneme";
            var article = await _unitOfWork.GetRepository<About>().GetAsync(x => !x.IsDeleted && x.Id == aboutUpdateDto.Id, i => i.Image);

            if (aboutUpdateDto.Photo != null)
            {
                if (article.Image != null && !string.IsNullOrEmpty(article.Image.FileName))
                {
                    ımageHelper.Delete(article.Image.FileName);
                }

                var imageUpload = await ımageHelper.Upload(aboutUpdateDto.Title, aboutUpdateDto.Photo, ImageType.Post);
                Image image = new Image(imageUpload.FullName, aboutUpdateDto.Photo.ContentType, userEmail);
                await _unitOfWork.GetRepository<Image>().AddAsync(image);

                article.Image = null;
                article.ImageId = image.Id;
            }

            // Sadece başlık ve içeriği güncellemek için kontroller ekleyin
            if (!string.IsNullOrEmpty(aboutUpdateDto.Title))
            {
                article.Title = aboutUpdateDto.Title;
            }

            if (!string.IsNullOrEmpty(aboutUpdateDto.Content))
            {
                article.Content = aboutUpdateDto.Content;
            }
            if (!string.IsNullOrEmpty(aboutUpdateDto.Person))
            {
                article.Person = aboutUpdateDto.Person;
            }
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;

            await _unitOfWork.GetRepository<About>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();

            return article.Title;
        }
    }
}
