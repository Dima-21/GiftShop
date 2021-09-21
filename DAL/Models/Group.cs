using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Group
    {
        public Group()
        {
            Goods = new HashSet<Goods>();
            Properties = new HashSet<Property>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescript { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public bool IsHidden { get; set; }
        public ICollection<Goods> Goods { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
