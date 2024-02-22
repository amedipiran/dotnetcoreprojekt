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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db){
            _db = db;
        }
        public void Save(){
            _db.SaveChanges();
        }
        public void Update(Category obj) {

            _db.Categories.Update(obj);

        }

    }

   
}