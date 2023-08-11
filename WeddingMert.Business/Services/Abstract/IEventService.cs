
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.DTOs.Abouts;
using WeddingMert.Entity.DTOs.Events;

namespace NovenaClinic.Business.Services.Abstract
{
    public interface IEventService
    {
        Task<List<EventDto>> GetAllEventAsync();
        Task<EventDto> GetEventAsync(Guid id);
        Task<string> UpdateEventAsync(EventUpdateDto eventUpdateDto);
    }
}
