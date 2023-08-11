using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.DTOs.Images;
using WeddingMert.Entity.Enums;

namespace WeddingMert.Business.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImagesUploadedDto> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null);
        void Delete(string imageName);
    }
}
