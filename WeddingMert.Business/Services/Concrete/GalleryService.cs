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
using WeddingMert.Entity.DTOs.Galleries;
using WeddingMert.Entity.Enums;

namespace WeddingMert.Business.Services.Concrete
{
    public class GalleryService : IGalleryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper ımageHelper;


        public GalleryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper ımageHelper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.ımageHelper = ımageHelper;
        }

        public async Task CreateGalleryAsync(GalleryAddDto galleryAddDto)
        {
            //var userId = Guid.Parse("ıd");
            var userEmail = "deneme";

            var imageUpload = await ımageHelper.Upload(galleryAddDto.Title, galleryAddDto.Photo, ImageType.Post);
            Image image = new(imageUpload.FullName, galleryAddDto.Photo.ContentType, userEmail);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);


            var gallery = new Gallery(galleryAddDto.Title,image.Id);
            await _unitOfWork.GetRepository<Gallery>().AddAsync(gallery);
            await _unitOfWork.SaveAsync();
        }

        public async Task<GalleryDto> GetGalleryAsync(Guid galleryId)
        {
            var gallery = await _unitOfWork.GetRepository<Gallery>().GetAsync(x => !x.IsDeleted && x.Id == galleryId, y => y.Image);
            var map = mapper.Map<GalleryDto>(gallery);
            return map;
        }

        public async Task<List<GalleryDto>> GetAllGalleryAsync()
        {
            var galleries = await _unitOfWork.GetRepository<Gallery>().GetAllAsync(x =>!x.IsDeleted, y => y.Image);
            var map = mapper.Map<List<GalleryDto>>(galleries);
            return map;
        }

        public async Task<string> SafeDeleteGalleryAsync(Guid galleryId)
        {
            var userEmail = "deneme";
            var gallery = await _unitOfWork.GetRepository<Gallery>().GetByGuidAsync(galleryId);


            gallery.IsDeleted = true;
            gallery.DeletedDate = DateTime.Now;
            gallery.DeletedBy = userEmail;


            await _unitOfWork.GetRepository<Gallery>().UpdateAsync(gallery);
            await _unitOfWork.SaveAsync();

            return gallery.Title;
        }
    }
}
