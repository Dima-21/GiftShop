using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Property
    {
        public Property()
        {
            Charact = new HashSet<Charact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFilter { get; set; }

        public ICollection<Charact> Charact { get; set; }
    }
}
