using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingMert.Entity.DTOs.Galleries
{
    public class GalleryAddDto
    {
        public string Title { get; set; }
        public IFormFile Photo { get; set; }
    }
}
