using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class DataManager
    {
        public IRepository<Goods> RepoGoods { get; private set; }
        public IRepository<Group> RepoGroup { get; private set; }
        public IRepository<GoodsImage> RepoGoodsImage { get; private set; }
        public IRepository<Image> RepoImage { get; private set; }
        public IRepository<Charact> RepoCharact { get; private set; }
        public IRepository<OrderGoods> RepoOrderGoods { get; private set; }
        public IRepository<Order> RepoOrder { get; private set; }
        public IRepository<Property> RepoProperty { get; private set; }
        public IRepository<CartItem> RepoCartItem { get; private set; }
        public IRepository<OrderStatus> RepoOrderStatus { get; private set; }
        public IRepository<AspNetUsers> RepoUsers { get; private set; }


        public DataManager(IRepository<Goods> repoGoods,
                           IRepository<Group> repoGroup,
                           IRepository<GoodsImage> repoGoodsImage,
                           IRepository<Image> repoImage,
                           IRepository<Charact> repoCharact,
                           IRepository<OrderGoods> repoOrderGoods,
                           IRepository<Order> repoOrder,
                           IRepository<Property> repoProperty,
                           IRepository<OrderStatus> repoOrderStatus,
                           IRepository<AspNetUsers> repoUsers,
                           IRepository<CartItem> repoCartItem)
        {
            RepoGoods = repoGoods;
            RepoGroup = repoGroup;
            RepoGoodsImage = repoGoodsImage;
            RepoImage = repoImage;
            RepoCharact = repoCharact;
            RepoOrderGoods = repoOrderGoods;
            RepoOrder = repoOrder;
            RepoProperty = repoProperty;
            RepoCartItem = repoCartItem;
            RepoOrderStatus = repoOrderStatus;
            RepoUsers = repoUsers;
        }
    }
}
