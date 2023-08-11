using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Business.Services.Abstract;
using WeddingMert.DataAccess.UnitOfWorks;
using WeddingMert.Entity.Concrete;
using WeddingMert.Entity.DTOs.Contacts;
using static System.Net.Mime.MediaTypeNames;
using WeddingMert.Entity.DTOs.Galleries;
using WeddingMert.Entity.DTOs.Abouts;

namespace WeddingMert.Business.Services.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ContactDto> GetContactAsync(Guid contactId)
        {

            var contact = await _unitOfWork.GetRepository<Contact>().GetAsync(x => !x.IsDeleted && x.Id == contactId);
            var map = mapper.Map<ContactDto>(contact);
            return map;
        }

        public async Task<List<ContactDto>> GetAllContactAsync()
        {
            var contacts = await _unitOfWork.GetRepository<Contact>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<ContactDto>>(contacts);
            return map;
        }
        public async Task SendMessageAsync(ContactAddDto contactAddDto)
        {

            var contact = new Contact(contactAddDto.Name,contactAddDto.Surname,contactAddDto.Mail,contactAddDto.Phone,contactAddDto.Message);
            await _unitOfWork.GetRepository<Contact>().AddAsync(contact);
            await _unitOfWork.SaveAsync();
        }
    }
}
