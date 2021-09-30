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

        public static IEnumerable<PropertyDTO> GetPropertiesWithCharact(this IEnumerable<PropertyDTO> properties)
        {
            return properties.Where(x => x.Charact != null && x.Charact.Count != 0);
        }

        public static IEnumerable<PropertyDTO> GetListPropertyForFilterGoods(this IEnumerable<PropertyDTO> properties, int? idGroup)
        {
            var result = properties
                .Where(x => x.IsFilter == true && x.Charact != null && x.Charact.Count != 0);

            if (idGroup != null)
                result = result.GetPropertiesByGroup((int)idGroup);

            return result;
        }
    }
}
