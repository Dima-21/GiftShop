//using DAL.Models;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DAL.Repositories
//{
//    class HproductRepository : IRepository<Hproduct>
//    {
//        GiftShopContext context = new GiftShopContext();

//        public void Create(Hproduct item)
//        {
//            context.Hproduct.Add(item);
//        }

//        public void Delete(int id)
//        {
//            context.Hproduct.Remove(Get(id));
//        }

//        public Hproduct Get(int id)
//        {
//            return context.Hproduct.Find(id);
//        }

//        public IEnumerable<Hproduct> GetAll()
//        {
//            return context.Hproduct;
//        }

//        public void Save()
//        {
//            context.SaveChangesAsync();
//        }

//        public void Update(Hproduct item)
//        {
//            context.Hproduct.Update(item);
//        }
//    }
//}
