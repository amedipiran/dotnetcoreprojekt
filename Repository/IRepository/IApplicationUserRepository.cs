using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Repository.IRepository {
    public interface IApplicationUserRepository : IRepository<ApplicationUser> {
        public void Update(ApplicationUser applicationUser);
 
    }
}