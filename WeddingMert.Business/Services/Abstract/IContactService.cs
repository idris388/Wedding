using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.DTOs.Abouts;
using WeddingMert.Entity.DTOs.Contacts;
using WeddingMert.Entity.DTOs.Galleries;

namespace WeddingMert.Business.Services.Abstract
{
    public interface IContactService
    {
        Task<List<ContactDto>> GetAllContactAsync(); 
        Task SendMessageAsync(ContactAddDto contactAddDto); 
        Task<ContactDto> GetContactAsync(Guid contactId);
    }
}
