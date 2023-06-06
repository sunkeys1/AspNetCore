using AspCore.DataAccess.Data;
using AspCore.DataAccess.Repository.IRepository;
using AspCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCore.DataAccess.Repository
{
    public class UserGroupRepository : Repository<UserGroup>, IUserGroupRepository
    {
        private ApplicationDbContext _db;
        public UserGroupRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(UserGroup obj)
        {
            // _db.Update(obj);   // возможно сюда нужно еще добавить .UserGroup.   // заменяем простой апдейт на вот енто
            var objFromDb = _db.UsersGroup.FirstOrDefault(u => u.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.Description = obj.Description;
                objFromDb.CreatedDate = obj.CreatedDate;
                objFromDb.Code = obj.Code;
                objFromDb.MemberId = obj.MemberId;
                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
