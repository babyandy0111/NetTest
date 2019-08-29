using System.Collections.Generic;
using System.Linq;
using AndyNetTest.Base.ApplicationDbContext;
using AndyNetTest.DataAccess.Interface;
using AndyNetTest.Entities.UserInfo;

namespace AndyNetTest.DataAccess.Implement
{
    public class UserInfoDao : IUserInfoDao
    {
        public ApplicationDbContext Context;

        public UserInfoDao(ApplicationDbContext context)
        {
            Context = context;
        }

        //插入資料
        public bool CreateUserInfo(UserInfo user)
        {
            Context.UserInfo.Add(user);
            return Context.SaveChanges() > 0;
        }

        //取全部記錄
        public IEnumerable<UserInfo> GetUserInfos()
        {
            return Context.UserInfo.ToList();
        }

        //取某id記錄
        public UserInfo GetUserInfoByID(int id)
        {
            return Context.UserInfo.SingleOrDefault(s => s.ID == id);
        }

        //根據id更新整條記錄
        public bool UpdateUserInfo(UserInfo user)
        {
            Context.UserInfo.Update(user);
            return Context.SaveChanges() > 0;
        }

        //根據id更新名稱
        public bool UpdateAddressByID(int id, string address)
        {
            var state = false;
            var tmp = Context.UserInfo.SingleOrDefault(s => s.ID == id);

            if (tmp != null)
            {
                tmp.Address = address;
                state = Context.SaveChanges() > 0;
            }

            return state;
        }

        //根據id刪掉記錄
        public bool DeleteUserInfoByID(int id)
        {
            var user = Context.UserInfo.SingleOrDefault(s => s.ID == id);
            Context.UserInfo.Remove(user);
            return Context.SaveChanges() > 0;
        }
    }
}
