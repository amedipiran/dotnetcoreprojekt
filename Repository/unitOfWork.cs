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
    public class UnitOfWork : IUnitOfWork
    {  private ApplicationDbContext _db;
        public ICategoryRepository Category { get;private set;}
               public IProductRepository Product { get;private set;}
               public ICompanyRepository Company { get;private set;}


        public UnitOfWork(ApplicationDbContext db) {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);


        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}