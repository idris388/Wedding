using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Core.Concrete;
using static System.Net.Mime.MediaTypeNames;

namespace WeddingMert.Entity.Concrete
{
    public class About: EntityBase
    {
        public string Person { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
