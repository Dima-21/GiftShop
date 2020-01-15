using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Image
    {
        public Image()
        {
            GoodsImage = new HashSet<GoodsImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Fext { get; set; }

        public ICollection<GoodsImage> GoodsImage { get; set; }
    }
}
