using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.Concrete;

namespace WeddingMert.Entity.DTOs.Galleries
{
    public class GalleryDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Image Image { get; set; }
        public bool IsDeleted { get; set; }
    }
}
