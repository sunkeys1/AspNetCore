using AspCore.DataAccess.Data;
using AspCore.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IUserRepository User { get; private set; }

        public IUserGroupRepository UserGroup { get; private set; }  

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            User = new UserRepository(_db);
            UserGroup = new UserGroupRepository(_db);

        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
