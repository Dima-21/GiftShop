using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Group
    {
        public Group()
        {
            Charact = new HashSet<Charact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescript { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime? DataEnd { get; set; }

        public ICollection<Charact> Charact { get; set; }
    }
}
