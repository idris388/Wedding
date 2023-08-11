using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.Concrete;

namespace WeddingMert.Entity.DTOs.Events
{
    public class EventUpdateDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string Title1 { get; set; }
        public string Address { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan Saat { get; set; }
        public Image Image { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
