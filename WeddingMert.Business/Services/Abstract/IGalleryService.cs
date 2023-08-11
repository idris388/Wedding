
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.DTOs.Abouts;
using WeddingMert.Entity.DTOs.Galleries;

namespace NovenaClinic.Business.Services.Abstract
{
    public interface IGalleryService
    {
        Task<List<GalleryDto>> GetAllGalleryAsync();
        Task<GalleryDto> GetGalleryAsync(Guid galleryId); 
        Task CreateGalleryAsync(GalleryAddDto galleryAddDto); 
        Task<string> SafeDeleteGalleryAsync(Guid galleryId);
    }
}
