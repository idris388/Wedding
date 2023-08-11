
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.DTOs.Abouts;

namespace NovenaClinic.Business.Services.Abstract
{
    public interface IAboutService
    {
        Task<List<AboutDto>> GetAllAboutAsync();
        Task<AboutDto> GetAboutAsync(Guid aboutId);
        Task<string> UpdateAboutAsync(AboutUpdateDto aboutUpdateDto);
    }
}
