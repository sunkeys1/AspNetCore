﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspCore.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // T - User
        IEnumerable<T> GetAll(string? includeProps = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProps = null);
        void Add(T entity);
        //void Update(T entity);
        void Delete(T entity);
    }
}
