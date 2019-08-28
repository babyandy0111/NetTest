using System.Collections.Generic;
using System.Linq;
using AndyNetTest.Base;
using AndyNetTest.DataAccess.Interface;
using Snai.Mysql.Entities;

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
        public IEnumerable<Users> GetUsers()
        {
            return Context.User.ToList();
        }

        //取某id記錄
        public Users GetUserByID(int id)
        {
            return Context.User.SingleOrDefault(s => s.ID == id);
        }

        //根據id更新整條記錄
        public bool UpdateUser(Users student)
        {
            Context.User.Update(student);
            return Context.SaveChanges() > 0;
        }

        //根據id更新名稱
        public bool UpdateNameByID(int id, string name)
        {
            var state = false;
            var student = Context.User.SingleOrDefault(s => s.ID == id);

            if (student != null)
            {
                student.Name = name;
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