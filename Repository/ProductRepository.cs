using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;
using Projekt.Repository.IRepository;

namespace Projekt.Repository {
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db){
            _db = db;
        }

        public void Update(Product obj) {

            var objFromDb = _db.Products.FirstOrDefault(u=>u.Id == obj.Id);
            if(objFromDb != null) {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.Author = obj.Author;
                objFromDb.Price = obj.Price;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;
                objFromDb.CategoryId = obj.CategoryId;
                if(obj.ImageUrl != null) {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }

            }

        }

    }

   
}