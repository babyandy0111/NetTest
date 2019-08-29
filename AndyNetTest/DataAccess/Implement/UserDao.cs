using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using AndyNetTest.Base.ApplicationDbContext;
using AndyNetTest.DataAccess.Interface;
using AndyNetTest.Entities.Users;
using AndyNetTest.Entities.UsersAndInfo;
using Dapper;

namespace AndyNetTest.DataAccess.Implement
{
    public class UserDao : IUserDao
    {
        public ApplicationDbContext Context;

        public UserDao(ApplicationDbContext context)
        {
            Context = context;
        }

        //插入資料
        public bool CreateUser(Users user)
        {
            Context.User.Add(user);
            return Context.SaveChanges() > 0;
        }

        //取全部記錄
        public IEnumerable<UsersAndInfo> GetUsers()
        {
            List<UsersAndInfo> listUser = new List<UsersAndInfo>();
            var data = (from a in Context.User
                       join b in Context.UserInfo on a.ID equals b.ID
                       select new UsersAndInfo()
                       {
                           ID=a.ID,
                          Name = a.Name,
                          Address = b.Address
                        }).ToList();

            //return Context.User.ToList();
            return data;
        }

        //取某id記錄
        public Users GetUserByID(int id)
        {
            return Context.User.SingleOrDefault(s => s.ID == id);
        }

        //根據id更新整條記錄
        public bool UpdateUser(Users user)
        {
            Context.User.Update(user);
            return Context.SaveChanges() > 0;
        }

        //根據id更新名稱
        public bool UpdateNameByID(int id, string name)
        {
            var state = false;
            var tmp = Context.User.SingleOrDefault(s => s.ID == id);

            if (tmp != null)
            {
                tmp.Name = name;
                state = Context.SaveChanges() > 0;
            }

            return state;
        }

        //根據id刪掉記錄
        public bool DeleteUserByID(int id)
        {
            var student = Context.User.SingleOrDefault(s => s.ID == id);
            Context.User.Remove(student);
            return Context.SaveChanges() > 0;
        }
    }
}