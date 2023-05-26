﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCore.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IUserGroupRepository UserGroup { get; }
        void Save(); 
    }
}
