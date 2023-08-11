using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Core.Concrete;

namespace WeddingMert.Entity.Concrete
{
    public class Event:EntityBase
    {
        public string? Title { get; set; }
        public string Title1 { get; set; }
        public string Address{ get; set; }
        public DateTime Tarih{ get; set; }
        public TimeSpan Saat { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
