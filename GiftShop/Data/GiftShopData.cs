using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Data
{
    public static class GiftShopData
    {
        public static void Initialize(GiftShopContext context)
        {
            if (!context.OrderStatus.Any())
            {
                context.OrderStatus.AddRange(
                    new OrderStatus
                    {
                        StatusName = "В обработке",
                        StatusCode = 1
                    },
                     new OrderStatus
                     {
                         StatusName = "Подтверждён",
                         StatusCode = 2
                     },
                     new OrderStatus
                     {
                         StatusName = "Доставляется",
                         StatusCode = 3
                     },
                      new OrderStatus
                      {
                          StatusName = "Завершён",
                          StatusCode = 4
                      }
                );
                context.SaveChanges();
            }
        }
    }
}
