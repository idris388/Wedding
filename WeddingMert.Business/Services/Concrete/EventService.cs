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
using WeddingMert.Entity.DTOs.Events;
using WeddingMert.Entity.Enums;

namespace WeddingMert.Business.Services.Concrete
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper ımageHelper;
        private readonly ClaimsPrincipal _user;
        public EventService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper ımageHelper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.ımageHelper = ımageHelper;
            _user = httpContextAccessor.HttpContext.User;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<EventDto>> GetAllEventAsync()
        {
            var events = await _unitOfWork.GetRepository<Event>().GetAllAsync(x => !x.IsDeleted, y => y.Image);
            var map = mapper.Map<List<EventDto>>(events);
            return map;
        }

        public async Task<EventDto> GetEventAsync(Guid id)
        {
            var events = await _unitOfWork.GetRepository<Event>().GetAsync(x => !x.IsDeleted && x.Id == id, y => y.Image);
            var map = mapper.Map<EventDto>(events);
            return map;
        }
        public async Task<string> UpdateEventAsync(EventUpdateDto eventUpdateDto)
        {
            var userEmail = "deneme";
            var events = await _unitOfWork.GetRepository<Event>().GetAsync(x => !x.IsDeleted && x.Id == eventUpdateDto.Id, i => i.Image);

            if (eventUpdateDto.Photo != null)
            {
                if (events.Image != null && !string.IsNullOrEmpty(events.Image.FileName))
                {
                    ımageHelper.Delete(events.Image.FileName);
                }

                var imageUpload = await ımageHelper.Upload(eventUpdateDto.Title, eventUpdateDto.Photo, ImageType.Post);
                Image image = new Image(imageUpload.FullName, eventUpdateDto.Photo.ContentType, userEmail);
                await _unitOfWork.GetRepository<Image>().AddAsync(image);

                events.Image = null;
                events.ImageId = image.Id;
            }

            // Sadece başlık ve içeriği güncellemek için kontroller ekleyin
            if (!string.IsNullOrEmpty(eventUpdateDto.Title))
            {
                events.Title = eventUpdateDto.Title;
            }
            if (!string.IsNullOrEmpty(eventUpdateDto.Title1))
            {
                events.Title1 = eventUpdateDto.Title1;
            }
            if (!string.IsNullOrEmpty(eventUpdateDto.Address))
            {
                events.Address = eventUpdateDto.Address;
            }

            events.Tarih = eventUpdateDto.Tarih;
            events.Saat = eventUpdateDto.Saat;

            events.ModifiedDate = DateTime.Now;
            events.ModifiedBy = userEmail;

            await _unitOfWork.GetRepository<Event>().UpdateAsync(events);
            await _unitOfWork.SaveAsync();

            return events.Title;
        }
    }
}
