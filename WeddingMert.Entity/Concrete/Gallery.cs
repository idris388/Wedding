using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Core.Concrete;

namespace WeddingMert.Entity.Concrete
{
    public class Gallery:EntityBase
    {
        public Gallery()
        {

        }

        public Gallery(string title, Guid imageId)
        {
            Title = title;

            ImageId = imageId;
        }
        public string Title { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
