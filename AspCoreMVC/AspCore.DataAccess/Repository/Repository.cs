using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspCore.DataAccess.Repository.IRepository;
using AspCore.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AspCore.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();    // _db.Users == dbSet -->>  dbSet.Add()   // по сути сразу переприсвоили чтобы в дальнейшем было удобнее обращаться

            _db.UsersGroup.Include(u => u.User).Include(u => u.MemberId);
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProps = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);       // User? userFromDb2 = _db.Users.Where(a => a.Id == id).FirstOrDefault();
            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includePro in includeProps
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includePro);
                }
            }
            return query.FirstOrDefault();     // используем ту же логику что и в UserController.cs (Edit)
        }

        public IEnumerable<T> GetAll(string? includeProps = null)
        {
            IQueryable<T> query = dbSet;
            if(!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includePro in includeProps
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includePro);
                }
            }
            return query.ToList();
        }
    }
}