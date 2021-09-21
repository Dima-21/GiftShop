using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Filters
{
    static public class PropertyDataFilter
    {
        public static IEnumerable<PropertyDTO> GetPropertiesByGroup(this IEnumerable<PropertyDTO> properties, int idGroup)
        {
            return properties.Where(x => x.GroupId == idGroup);
        }
    }
}
