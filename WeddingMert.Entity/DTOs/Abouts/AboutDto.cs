using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.Concrete;

namespace WeddingMert.Entity.DTOs.Abouts
{
    public class AboutDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Person { get; set; }
        public Image Image { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
