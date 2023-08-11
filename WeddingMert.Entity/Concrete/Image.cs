using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Core.Concrete;

namespace WeddingMert.Entity.Concrete
{
    public class Image: EntityBase
    {
        public Image()
        {

        }
        public Image(string filename, string filetype, string createdBy)
        {
            FileName = filename;
            FileType = filetype;
            CreatedBy = createdBy;
        }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<About> Abouts { get; set; }
        public ICollection<Gallery>Galleries{ get; set; }
        public ICollection<Event>Events{ get; set; }
    }
}
