using DAL.Models;
using Microsoft.AspNetCore.Identity;
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

            //var user1 = new AspNetUsers
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    UserName = "GiftShopAdmin",
            //    Email = "admin@magicgift.com",
            //    PasswordHash = "admin@magicgift.com",
            //    EmailConfirmed = true,
            //};
            //context.AspNetUsers.Add(user1);

            //var userroles1 = new AspNetUserRoles()
            //{
            //    RoleId = context.AspNetRoles.First().Id,
            //    UserId = user1.Id
            //};

            //var userroles2 = new AspNetUserRoles()
            //{
            //    RoleId = context.AspNetRoles.Last().Id,
            //    UserId = user1.Id
            //};
            //context.AspNetUserRoles.Add(userroles1);
            //context.AspNetUserRoles.Add(userroles2);
            //context.SaveChanges();


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

            if (!context.AspNetRoles.Any())
            {
                context.AspNetRoles.AddRange(
                    new AspNetRoles
                    {
                        Name = "Админ",
                        NormalizedName = "АДМИН"
                    },
                     new AspNetRoles
                     {
                         Name = "Модератор",
                         NormalizedName = "МОДЕРАТОР"
                     }
                );
                context.SaveChanges();
            }



            if (!context.AspNetUsers.Any())
            {
                var user = new AspNetUsers
                {
                    UserName = "GiftShopModerator",
                    Email = "giftshop.saless@gmail.com",
                    EmailConfirmed = true,
                };

                context.AspNetUsers.Add(user);

                var userroles = new AspNetUserRoles()
                {
                    RoleId = context.AspNetRoles.First().Id,
                    UserId = user.Id
                };


                context.AspNetUserRoles.Add(userroles);
                context.SaveChanges();
            }
        }
    }
}
