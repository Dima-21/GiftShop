using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Filters
{
    public static class GoodsDTOExtension
    {
        public static IEnumerable<GoodsDTO> GetGoodsByGroup(this IEnumerable<GoodsDTO> goods, int idGroup)
        {
            return goods.Where(x => x.Group.Id == idGroup);
        }

        public static IEnumerable<GoodsDTO> GetIsEnabled(this IEnumerable<GoodsDTO> goods)
        {
            var result = goods.Where(x => x.IsHidden == false);

            return result;
        }
    }
}
